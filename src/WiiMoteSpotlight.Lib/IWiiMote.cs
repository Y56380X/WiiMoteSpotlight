using System;

namespace WiiMoteSpotlight.Lib
{
	public interface IWiiMote
	{
		event EventHandler<ConsoleKey> KeyPress;
	}
}