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
using System.Runtime.InteropServices;
using WiiMoteSpotlight.Lib.XWiiMote.Swig;

namespace WiiMoteSpotlight.Lib.XWiiMote.EventData
{
	public class EventInt : IDisposable
	{
		private readonly IntPtr _maPtr;
		private SWIGTYPE_p_int _internalW;

		public EventInt()
		{
			int size = Marshal.SizeOf(typeof(int));
			_maPtr = Marshal.AllocHGlobal(size);
		}

		public int Get() => Marshal.ReadInt32(_maPtr);

		public static implicit operator SWIGTYPE_p_int(EventInt d) => 
			d._internalW ??= new SWIGTYPE_p_int(d._maPtr, true);

		public static implicit operator int(EventInt d) => d.Get();

		public void Dispose() => Marshal.FreeHGlobal(_maPtr);
	}
}