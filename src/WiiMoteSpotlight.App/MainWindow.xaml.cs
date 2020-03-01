using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using WiiMoteSpotlight.Lib;

namespace WiiMoteSpotlight.App
{
	public class MainWindow : Window
	{
		private IWiiMote WiiMote { get; } = App.Services.GetService<IWiiMote>();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}