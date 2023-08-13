using UnityEngine;
using TMPro;

using System.Collections;

using LootLocker;
using LootLocker.Requests;

namespace BallsComing
{
	public class PlayerLogin : MonoBehaviour
	{
		private LeaderboardsManager leaderboardsManager;

		private TMP_InputField usernameInputField;

        private void Awake()
        {
			leaderboardsManager = GetComponent<LeaderboardsManager>();

			usernameInputField = GameObject.Find("Username Input Field").GetComponent<TMP_InputField>();
		}

		[System.Obsolete]
		private void Start()
        {
			StartCoroutine(SetupRoutine());
        }

		[System.Obsolete]
		private IEnumerator SetupRoutine()
        {
			yield return LoginRoutine();

			yield return leaderboardsManager.FetchTopHighCoinsRoutine();
			yield return leaderboardsManager.FetchCurrentPlayerHighCoinsRoutine();
		}

        private IEnumerator LoginRoutine()
        {
			bool done = false;

			LootLockerSDKManager.StartGuestSession((response) =>
			{
				if (response.success)
				{
					PlayerPrefs.SetString("PlayerID", response.player_id.ToString());

					done = true;
				}

				else done = true;
			});

			yield return new WaitWhile(() => done == false);
        }

		[System.Obsolete]
		public void SetPlayerName()
		{
			LootLockerSDKManager.SetPlayerName(usernameInputField.text, (response) =>
			{
				if (response.success)
					StartCoroutine(SetupRoutine());
			});
		}
	}
}