using System;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
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
			WiiMote.KeyRelease += WiiMoteOnKeyRelease;
		}
		
		private void WiiMoteOnKeyPress(object? sender, ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.B:
					Dispatcher.UIThread.InvokeAsync(Show);
					break;
			}
		}
		
		private void WiiMoteOnKeyRelease(object? sender, ConsoleKey key)
		{
			switch (key)
			{
				case ConsoleKey.B:
					Dispatcher.UIThread.InvokeAsync(Hide);
					break;
			}
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}