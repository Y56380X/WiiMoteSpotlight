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
using WiiMoteSpotlight.Lib.XWiiMote.Swig;

namespace WiiMoteSpotlight.Lib.XWiiMote
{
	public class WiiMote : IWiiMote
	{
		public event EventHandler<ConsoleKey> KeyPress;
		public event EventHandler<ConsoleKey> KeyRelease;

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
			                     xwii_iface_type.IFACE_MOTION_PLUS));

			_device.set_mp_normalization(-266, 2500, -1160, 50);
			
			Task.Run(InputEventLoop);
		}

		private void InputEventLoop()
		{
			while (true)
			{
				if (!TryDispatchEvent(out var wiiEvent))
					Thread.Sleep(1);
				
				xwii_event_types eventType = (xwii_event_types)wiiEvent.type;
				
				switch (eventType)
				{
					case xwii_event_types.EVENT_KEY:
						break;
				}
			}
		}

		private bool TryDispatchEvent(out xwii_event_ wiiEvent)
		{
			wiiEvent = new xwii_event_();
			
			try
			{
				_device.dispatch(wiiEvent);
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