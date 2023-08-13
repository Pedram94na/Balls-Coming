using UnityEngine;

namespace BallsComing.Core
{
	public class InputManager
	{
		private InputManager() { }

		public static readonly InputManager instance = new();
		public static InputManager Instance
		{
			get { return instance; }
		}

		public float HorizontalInput() { return Input.GetAxis("Horizontal"); }

		public bool JumpingInput() { return Input.GetButton("Jump"); }

		public bool PauseInput() { return Input.GetKeyDown(KeyCode.Escape); }
	}
}