using System;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Microsoft.Extensions.DependencyInjection;
using WiiMoteSpotlight.Lib;

namespace WiiMoteSpotlight.App
{
	public class MainWindow : FullscreenWindow
	{
		private readonly IWiiMote _wiiMote;
		private readonly Control _pointer;

		public MainWindow()
		{
			InitializeComponent();
			
			// Initialize private fields
			_wiiMote = App.Services.GetService<IWiiMote>();
			_pointer = this.FindControl<Ellipse>("pointer");
			
			// Subscribe to WiiMote events
			_wiiMote.KeyPress += WiiMoteOnKeyPress;
			_wiiMote.KeyRelease += WiiMoteOnKeyRelease;
		}
		
		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
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

		public override void Show()
		{
			base.Show();
			_pointer.IsVisible = true;
		}

		public override void Hide()
		{
			base.Hide();
			_pointer.IsVisible = false;
		}
	}
}