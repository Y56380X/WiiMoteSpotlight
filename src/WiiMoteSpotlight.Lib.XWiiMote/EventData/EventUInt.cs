using System;
using System.Runtime.InteropServices;
using WiiMoteSpotlight.Lib.XWiiMote.Swig;

namespace WiiMoteSpotlight.Lib.XWiiMote.EventData
{
	public class EventUInt : IDisposable
	{
		private readonly IntPtr maPtr;
		private SWIGTYPE_p_unsigned_int internalW;

		public EventUInt()
		{
			int size = Marshal.SizeOf(typeof(uint));
			maPtr = Marshal.AllocHGlobal(size);
		}

		public int Get()
		{
			return Marshal.ReadInt32(maPtr);
		}
		
		public static implicit operator SWIGTYPE_p_unsigned_int(EventUInt d)
		{
			return d.internalW ??= new SWIGTYPE_p_unsigned_int(d.maPtr, true);
		}

		public void Dispose()
		{
			Marshal.FreeHGlobal(maPtr);
		}
	}
}