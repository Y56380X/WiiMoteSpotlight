using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenTK.Input;

namespace WiiMoteSpotlight.Lib.Virtual
{
	public class WiiMote : IWiiMote
	{
		public event EventHandler<ConsoleKey> KeyPress;
		public event EventHandler<ConsoleKey> KeyRelease;

		private IDictionary<Key, bool> _keyStatus = new Dictionary<Key, bool>();

		public WiiMote() => Task.Run(InputEventLoop);

		private bool IsKeyStatusPressed(Key key)
		{
			if (!_keyStatus.TryGetValue(key, out _))
				_keyStatus.Add(key, false);
			return _keyStatus[key];
		}
		
		private void InputEventLoop()
		{
			while (true)
			{
				var keyboardState = Keyboard.GetState();
				
				if (keyboardState.IsKeyDown(Key.B) && !IsKeyStatusPressed(Key.B))
				{
					KeyPress?.Invoke(this, ConsoleKey.B);
					_keyStatus[Key.B] = true;
				}
				if (keyboardState.IsKeyUp(Key.B) && IsKeyStatusPressed(Key.B))
				{
					KeyRelease?.Invoke(this, ConsoleKey.B);
					_keyStatus[Key.B] = false;
				}
				
				Thread.Sleep(100);
			}
		}

		public void Dispose()
		{
		}
	}
}