using System;
using System.Threading;
using System.Threading.Tasks;

namespace WiiMoteSpotlight.Lib.WiimoteLib
{
	public class WiiMote : IWiiMote
	{
		public event EventHandler<ConsoleKey> KeyPress;
		public event EventHandler<ConsoleKey> KeyRelease;
		public event EventHandler<(int x, int y)> PointerMoved;

		private readonly global::WiimoteLib.Wiimote _device;
		
		public WiiMote()
		{
			// Connect to device
			_device = new global::WiimoteLib.Wiimote();
			_device.Connect();
			
			// Start processing loops
			Task.Run(InputEventLoop);
		}

		private void InputEventLoop()
		{
			while (true)
			{
				_device.GetStatus();
				
				if (_device.WiimoteState.ButtonState.B)
					
				
				Thread.Sleep(1);
			}
		}

		public void Dispose()
		{
			_device.Dispose();
		}
	}
}