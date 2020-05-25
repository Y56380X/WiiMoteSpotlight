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
using System.IO;
using System.Threading;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using WiiMoteSpotlight.Lib;

namespace WiiMoteSpotlight.App
{
	public class App : Application
	{
		private static bool UseVirtual { get; } = false;
		public static ServiceProvider Services { get; private set; }

		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			Services = serviceCollection.BuildServiceProvider();
		}

		private static void ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient(CreateWiiMote);
		}

		private static IWiiMote CreateWiiMote(IServiceProvider serviceProvider)
		{
			if (UseVirtual)
				return new Lib.Virtual.WiiMote();

			IWiiMote? wiiMote = null;

			do
			{
				try
				{
					wiiMote = Environment.OSVersion.Platform switch
					{
						PlatformID.Unix => new Lib.XWiiMote.WiiMote(),
						PlatformID.Win32NT => new Lib.WiimoteLib.WiiMote(),
						_ => throw new PlatformNotSupportedException()
					};
				}
				catch (IOException)
				{
					Console.WriteLine("Wait for wiimote!");
					Thread.Sleep(TimeSpan.FromSeconds(5));
				}
			} while (wiiMote == null);

			Console.WriteLine("Wiimote connected");

			return wiiMote;
		}

		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
				desktop.MainWindow = new MainWindow();

			base.OnFrameworkInitializationCompleted();
		}
	}
}