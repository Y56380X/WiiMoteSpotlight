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
using System.Threading;
using System.Threading.Tasks;
using WiiMoteSpotlight.Lib.XWiiMote.EventData;
using WiiMoteSpotlight.Lib.XWiiMote.Swig;

namespace WiiMoteSpotlight.Lib.XWiiMote
{
	public class WiiMote : IWiiMote
	{
		public event EventHandler<ConsoleKey> KeyPress;
		public event EventHandler<ConsoleKey> KeyRelease;
		public event EventHandler<(int x, int y)> PointerMoved;

		private readonly iface _device;

		public WiiMote()
		{
			// Get wiimote system path
			using var monitor = new monitor(true, true);
			var sysPath = monitor.poll();
			monitor.Dispose();

			// Open wiimote
			_device = new iface(sysPath);
			_device.open((uint) (xwii_iface_type.IFACE_CORE | xwii_iface_type.IFACE_WRITABLE |
			                     xwii_iface_type.IFACE_ACCEL));

			_device.set_mp_normalization(-266, 2500, -1160, 50);
			
			Task.Run(InputEventLoop);
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
						KeyRelease?.Invoke(this, ConsoleKey.B);
					if (keyPressed == xwii_event_keys.KEY_B && state.Get() == 1)
						KeyPress?.Invoke(this, ConsoleKey.B);
					break;
				}
				case xwii_event_types.EVENT_ACCEL:
				{
					using var x = new EventInt();
					using var y = new EventInt();
					using var z = new EventInt();
					
					inputEvent.get_abs(0, x, y, z);
					PointerMoved?.Invoke(this, (x.Get(), y.Get()));
					
					break;
				}
			}
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