using System;
using WiimoteLib;

namespace WiiMoteSpotlight.Lib.WiimoteLib
{
	internal class WiiMoteDeviceInfo : IDeviceInfo
	{
		private readonly Wiimote _device;

		public byte BatteryPercentage => Convert.ToByte(_device.WiimoteState.Battery);

		public WiiMoteDeviceInfo(Wiimote device) => _device = device;
	}
}