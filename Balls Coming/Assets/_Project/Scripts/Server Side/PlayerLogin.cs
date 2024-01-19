using UnityEngine;

using System.Collections;

using LootLocker.Requests;

namespace BallsComing.ServerSide
{
	public class PlayerLogin : MonoBehaviour
	{
		private LeaderboardsManager leaderboardsManager;
		private ItchIoAuth itchIoAuth;

		private string itchIoUsername = "Test Name";

        private void Awake()
        {
			itchIoAuth = ItchIoAuth.instance;
            leaderboardsManager = GetComponent<LeaderboardsManager>();
        }

        [System.Obsolete]
		private void Start()
        {
			StartCoroutine(SetupRoutine());
        }

		[System.Obsolete]
		private IEnumerator SetupRoutine()
        {
			//yield return itchIoAuth.FetchItchUsername(RecieveItchIoUsername);

			yield return LoginRoutine();

			SetPlayerName();
			
			yield return leaderboardsManager.FetchTopHighCoinsRoutine();
			yield return leaderboardsManager.FetchCurrentPlayerHighCoinsRoutine();
		}

		private void RecieveItchIoUsername(string itchIoUsername)
		{
			Debug.Log($"Itch.io Username: {itchIoUsername} !");

            this.itchIoUsername = itchIoUsername;
            //this.itchIoUsername = "Test Name";
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
			LootLockerSDKManager.SetPlayerName(itchIoUsername, (response) =>
			{
				//if (response.success)
					//StartCoroutine(SetupRoutine());

				if (response.success)
                    Debug.Log($"Player's name on leaderboards: {itchIoUsername} !");
            });
		}
	}
}