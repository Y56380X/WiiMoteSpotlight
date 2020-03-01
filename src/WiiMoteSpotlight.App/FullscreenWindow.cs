/*
    Copyright (c) 2020 Y56380X
    
	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:
	
	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.
	
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
*/

using System;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;
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
			switch (Environment.OSVersion.Platform)
			{
				case PlatformID.Unix:
					EnableFullscreenLinux();
					break;
				default:
					EnableFullscreenOtherPlatforms();
					break;
			}
		}

		private void EnableFullscreenOtherPlatforms()
		{
			HasSystemDecorations = false;
			WindowState = WindowState.Maximized;
		}

		private void EnableFullscreenLinux()
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