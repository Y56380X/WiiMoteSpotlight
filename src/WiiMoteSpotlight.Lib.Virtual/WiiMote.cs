using System;

namespace WiiMoteSpotlight.Lib.Virtual
{
	public class WiiMote : IWiiMote
	{
		public event EventHandler<ConsoleKey> KeyPress;
	}
}