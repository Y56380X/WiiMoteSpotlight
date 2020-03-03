using System;
using WiimoteLib;

namespace WiiMoteSpotlight.Lib.WiimoteLib
{
	public class WiiMote : IWiiMote
	{
		public event EventHandler<ConsoleKey> KeyPress;
		public event EventHandler<ConsoleKey> KeyRelease;
		public event EventHandler<(int x, int y)> PointerMoved;

		private readonly Wiimote _device;
		
		public WiiMote()
		{
			// Connect to device
			_device = new Wiimote();
			_device.Connect();
			Console.WriteLine("WiiMote connected!");
			
			// Initialize device
			_device.SetLEDs(true, false, false, false);

			// Start processing loops
			_device.WiimoteChanged += DeviceOnWiimoteChanged;
		}

		private void DeviceOnWiimoteChanged(object sender, WiimoteChangedEventArgs e)
		{
			if (e.WiimoteState.ButtonState.B)
				KeyPress.InvokeAsync(this, ConsoleKey.B);
			if (!e.WiimoteState.ButtonState.B)
				KeyRelease.InvokeAsync(this, ConsoleKey.B);
		}

		public void Dispose()
		{
			_device.Dispose();
			Console.WriteLine("WiiMote disposed!");
		}
	}
}