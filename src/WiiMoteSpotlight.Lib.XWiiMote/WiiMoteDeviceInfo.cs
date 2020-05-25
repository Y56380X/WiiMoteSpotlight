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
using WiiMoteSpotlight.Lib.XWiiMote.Swig;

namespace WiiMoteSpotlight.Lib.XWiiMote
{
	internal class WiiMoteDeviceInfo : IDeviceInfo
	{
		private readonly iface _device;
		private (byte batteryPercentage, DateTime update) _batteryPercentageStore;

		public byte BatteryPercentage => GetBatteryPercentage();

		public WiiMoteDeviceInfo(iface device)
		{
			_device = device;
		}

		private byte GetBatteryPercentage()
		{
			if (DateTime.Now.Subtract(_batteryPercentageStore.update).TotalSeconds < 1)
				return _batteryPercentageStore.batteryPercentage;
			_batteryPercentageStore.update = DateTime.Now;
			lock (_device)
				_batteryPercentageStore.batteryPercentage = (byte)_device.get_battery();
			return _batteryPercentageStore.batteryPercentage;
		}
	}
}