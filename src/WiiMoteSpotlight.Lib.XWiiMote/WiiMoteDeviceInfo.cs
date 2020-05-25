using WiiMoteSpotlight.Lib.XWiiMote.Swig;

namespace WiiMoteSpotlight.Lib.XWiiMote
{
	internal class WiiMoteDeviceInfo : IDeviceInfo
	{
		private readonly iface _device;

		public byte BatteryPercentage => (byte)_device.get_battery();

		public WiiMoteDeviceInfo(iface device)
		{
			_device = device;
		}
	}
}