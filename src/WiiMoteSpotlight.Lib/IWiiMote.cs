using System;

namespace WiiMoteSpotlight.Lib
{
	public interface IWiiMote : IDisposable
	{
		event EventHandler<ConsoleKey> KeyPress;
		event EventHandler<ConsoleKey> KeyRelease;
	}
}