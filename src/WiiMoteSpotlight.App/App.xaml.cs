using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using WiiMoteSpotlight.Lib;

namespace WiiMoteSpotlight.App
{
	public class App : Application
	{
		private static bool UseVirtual { get; } = true;
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

			return Environment.OSVersion.Platform switch
			{
				PlatformID.Unix => new Lib.XWiiMote.WiiMote(),
				_ => throw new PlatformNotSupportedException()
			};
		}

		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
			{
				desktop.MainWindow = new MainWindow();
			}

			base.OnFrameworkInitializationCompleted();
		}
	}
}