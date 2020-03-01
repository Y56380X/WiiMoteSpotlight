using System;
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
			var s = new monitor(true, true);
			var sysPath = s.poll();
			s.Dispose();
			
			_device = new iface(sysPath);

			Console.WriteLine($"Use Device {_device.get_syspath()}");
			Console.WriteLine($"fd: {_device.get_fd()}");
			Console.WriteLine("Open Writeable");

			_device.open((uint)(xwii_iface_type.IFACE_CORE | xwii_iface_type.IFACE_WRITABLE | xwii_iface_type.IFACE_MOTION_PLUS));

			_device.set_mp_normalization(-266, 2500, -1160, 50);
		}
		
		public void Dispose()
		{
			_device.Dispose();
		}
	}
}