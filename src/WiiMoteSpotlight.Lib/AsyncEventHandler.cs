using System;
using System.Threading.Tasks;

namespace WiiMoteSpotlight.Lib
{
	public static class AsyncEventHandler
	{
		public static Task InvokeAsync<T>(this EventHandler<T> eventHandler, object sender, T data) =>
			Task.Run(() => eventHandler?.Invoke(sender, data));
	}
}