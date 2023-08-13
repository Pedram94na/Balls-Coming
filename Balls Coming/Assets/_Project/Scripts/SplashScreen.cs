using UnityEngine;

namespace BallsComing
{
	public class SplashScreen
	{
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        static void OnBeforeSplashScreen()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}