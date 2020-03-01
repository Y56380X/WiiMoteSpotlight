using System;
using System.Reflection;
using System.Runtime.Loader;
using Avalonia.Controls;

namespace WiiMoteSpotlight.App
{
	public class FullscreenWindow : Window
	{
		public override void Show()
		{
			base.Show();
			EnableFullscreen();
		}

		private void EnableFullscreen()
		{
			IntPtr displayPointer;
			IntPtr fullscreen;
			IntPtr wmstate;
			MethodInfo sendXEvent;
			MethodInfo getAtom;

			// R
			object vfd = PlatformImpl.GetType().GetField("_x11", BindingFlags.Instance | BindingFlags.NonPublic)
				.GetValue(PlatformImpl);

			displayPointer = (IntPtr)vfd.GetType().GetProperty("Display")
				.GetValue(vfd);

			// M
			getAtom = AssemblyLoadContext.Default.
				LoadFromAssemblyName(new AssemblyName("Avalonia.X11"))
				.GetType("Avalonia.X11.XLib")
				.GetMethod("XInternAtom");

			fullscreen = (IntPtr)getAtom.Invoke(null, new object[]{ displayPointer, "_NET_WM_STATE_FULLSCREEN", false });
			wmstate = (IntPtr)getAtom.Invoke(null, new object[]{ displayPointer, "_NET_WM_STATE", false });
			
			sendXEvent = PlatformImpl.GetType()
				.GetMethod("SendNetWMMessage", BindingFlags.Instance | BindingFlags.NonPublic);

			sendXEvent.Invoke(PlatformImpl, new object[]{ wmstate, (IntPtr)1, fullscreen, IntPtr.Zero, null, null });
		}
	}
}