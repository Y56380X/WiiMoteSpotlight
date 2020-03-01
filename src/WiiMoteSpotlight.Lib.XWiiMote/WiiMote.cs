/*
    Copyright (c) 2020 Y56380X
    
	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:
	
	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.
	
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WiiMoteSpotlight.Lib.XWiiMote.EventData;
using WiiMoteSpotlight.Lib.XWiiMote.Swig;

namespace WiiMoteSpotlight.Lib.XWiiMote
{
	static class AsyncEventHandler
	{
		public static Task InvokeAsync<T>(this EventHandler<T> eventHandler, object sender, T data) =>
			Task.Run(() => eventHandler?.Invoke(sender, data));
	}
	
	public class WiiMote : IWiiMote
	{
		public event EventHandler<ConsoleKey> KeyPress;
		public event EventHandler<ConsoleKey> KeyRelease;
		public event EventHandler<(int x, int y)> PointerMoved;

		private readonly iface _device;
		private readonly Queue<(DateTime timestamp, int x, int z)> _gyroValues;

		private decimal _xAngle;
		private decimal _zAngle;
		
		public WiiMote()
		{
			_gyroValues = new Queue<(DateTime timestamp, int x, int z)>();
			
			// Get wiimote system path
			using var monitor = new monitor(true, true);
			var sysPath = monitor.poll();
			monitor.Dispose();

			// Open wiimote
			_device = new iface(sysPath);
			_device.open((uint) (xwii_iface_type.IFACE_CORE | xwii_iface_type.IFACE_WRITABLE |
			                     xwii_iface_type.IFACE_MOTION_PLUS));

			_device.set_mp_normalization(-266, 2500, -740, 50);
			
			// Start processing loops
			Task.Run(InputEventLoop);
			Task.Run(GyroProcessingLoop);
		}

		private static (int x, int y) ToPosition(decimal xAngle, decimal zAngle)
		{
			// Convert orientation to screen position
			var xPos = 960 + Math.Sin((double)-xAngle * Math.PI / 180) * 1920;
			var yPos = 540 + Math.Sin((double)zAngle * Math.PI / 180) * 1080;
			
			return ((int)xPos, (int)yPos);
		}
		
		private void GyroProcessingLoop()
		{
			(DateTime timestamp, int x, int z) last = (DateTime.Now, 0, 0);
			while (true)
			{
				bool hasData;
				lock (_gyroValues)
					hasData = _gyroValues.Any();
				if (!hasData)
				{
					Thread.Sleep(1);
					continue;
				}

				(DateTime timestamp, int x, int z) current;
				lock (_gyroValues) current = _gyroValues.Dequeue();
				
				var timeDifference = current.timestamp.Subtract(last.timestamp);
				if (Math.Abs(last.x) > 85)
				{
					_xAngle += (decimal)(last.x * timeDifference.TotalSeconds * 0.0072);
					PointerMoved.InvokeAsync(this, ToPosition(_xAngle, _zAngle));
				}

				if (Math.Abs(last.z) > 165)
				{
					_zAngle += (decimal)(last.z * timeDifference.TotalSeconds * 0.0072);
					PointerMoved.InvokeAsync(this, ToPosition(_xAngle, _zAngle));
				}

				last = current;
			}
		}

		private void InputEventLoop()
		{
			while (true)
			{
				if (!TryDispatchEvent(out var inputEvent))
					Thread.Sleep(1);

				HandleInputEvent(inputEvent);
			}
		}

		private void HandleInputEvent(in xwii_event_ inputEvent)
		{
			xwii_event_types eventType = (xwii_event_types)inputEvent.type;
				
			switch (eventType)
			{
				case xwii_event_types.EVENT_KEY:
				{
					using var key = new EventUInt();
					using var state = new EventUInt();
					inputEvent.get_key(key, state);
					var keyPressed = (xwii_event_keys) key.Get();

					if (keyPressed == xwii_event_keys.KEY_B && state.Get() == 0)
						KeyRelease.InvokeAsync(this, ConsoleKey.B);
					if (keyPressed == xwii_event_keys.KEY_B && state.Get() == 1)
						KeyPress.InvokeAsync(this, ConsoleKey.B);
					if (keyPressed == xwii_event_keys.KEY_HOME && state.Get() == 1)
						HomePointer();
					
					break;
				}
				case xwii_event_types.EVENT_MOTION_PLUS:
				{
					using var x = new EventInt();
					using var y = new EventInt();
					using var z = new EventInt();
					
					inputEvent.get_abs(0, x, y, z);
					var value = (DateTime.Now, x, z);
					lock (_gyroValues) _gyroValues.Enqueue(value);
					
					break;
				}
			}
		}

		private void HomePointer()
		{
			_xAngle = 0;
			_zAngle = 0;
			PointerMoved.InvokeAsync(this, ToPosition(_xAngle, _zAngle));
		}

		private bool TryDispatchEvent(out xwii_event_ inputEvent)
		{
			inputEvent = new xwii_event_();
			
			try
			{
				_device.dispatch(inputEvent);
			}
			catch
			{
				return false;
			}

			return true;
		}

		public void Dispose()
		{
			_device.Dispose();
			Console.WriteLine("WiiMote disposed");
		}
	}
}