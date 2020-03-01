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
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
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
			_wiiMote.PointerMoved += WiiMoteOnPointerMoved;
			PointerMoved += OnPointerMoved;
			
			// Start application hidden
			Task.Delay(100).ContinueWith(_ => Dispatcher.UIThread.InvokeAsync(Hide));
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
		
		private void WiiMoteOnPointerMoved(object? sender, (int x, int y) args)
		{
			Console.WriteLine(args);
		}
		
		private void OnPointerMoved(object? sender, PointerEventArgs args)
		{
			var pos = args.GetPosition(this);

			_pointer.SetValue(Canvas.LeftProperty, pos.X - _pointer.Width / 2);
			_pointer.SetValue(Canvas.TopProperty, pos.Y - _pointer.Height / 2);
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