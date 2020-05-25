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
using System.ComponentModel;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WiiMoteSpotlight.Lib;

namespace WiiMoteSpotlight.App
{
	public class DeviceInfoWindow : Window, INotifyPropertyChanged
	{
		public new event PropertyChangedEventHandler PropertyChanged;
		
		private readonly IDeviceInfo _deviceInfo;

		public byte BatteryPercentage => _deviceInfo.BatteryPercentage;
		
		private class NullDeviceInfo : IDeviceInfo
		{
			public byte BatteryPercentage => throw new NotSupportedException();
		}
		
		// ReSharper disable once UnusedMember.Global
		public DeviceInfoWindow()
		{
			_deviceInfo = new NullDeviceInfo();
			InitializeComponent();
		}
		
		public DeviceInfoWindow(IDeviceInfo deviceInfo = null)
		{
			_deviceInfo = deviceInfo;
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
			DataContext = this;
		}

		public override void Show()
		{
			base.Show();
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BatteryPercentage)));
		}
	}
}