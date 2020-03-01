using System;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using WiiMoteSpotlight.Lib;

namespace WiiMoteSpotlight.App
{
	public class MainWindow : FullscreenWindow
	{
		private IWiiMote WiiMote { get; } = App.Services.GetService<IWiiMote>();

		public MainWindow()
		{
			InitializeComponent();
			
			// Subscribe to WiiMote events
			WiiMote.KeyPress += WiiMoteOnKeyPress;
		}

		private void WiiMoteOnKeyPress(object? sender, ConsoleKey e)
		{
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}