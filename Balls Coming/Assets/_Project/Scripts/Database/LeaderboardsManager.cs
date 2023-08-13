using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using System.Collections;
using LootLocker.Requests;

namespace BallsComing
{
	public class LeaderboardsManager : MonoBehaviour
	{
		public struct ResultSet
        {
			public TextMeshProUGUI usernames;
			public TextMeshProUGUI highCoins;

			public TextMeshProUGUI currentUsername;
			public TextMeshProUGUI currentHighCoins;
		};
		public ResultSet resultSet;

		private readonly int leaderboardID = 16602;

		private int sceneIndex;

        private void Awake()
		{
			sceneIndex = SceneManager.GetActiveScene().buildIndex;

			InitializingLeaderboard();
		}

		private void InitializingLeaderboard()
		{
			GameObject leaderboardPanel = GameObject.Find("Leaderboard Panel");

			resultSet.usernames = leaderboardPanel.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
			resultSet.highCoins = leaderboardPanel.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();

			resultSet.currentUsername = leaderboardPanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
			resultSet.currentHighCoins = leaderboardPanel.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
		}

		[System.Obsolete]
		private void Start()
        {
			if (sceneIndex == 1)
				StartCoroutine(SetupRoutine());
        }

		[System.Obsolete]
		private IEnumerator SetupRoutine()
		{
			yield return FetchTopHighCoinsRoutine();
			yield return FetchCurrentPlayerHighCoinsRoutine();
		}

        [System.Obsolete]
        public IEnumerator SubmitCoinRoutine(int coinsToUload)
        {
			bool done = false;
			string playerID = PlayerPrefs.GetString("PlayerID");

			if (coinsToUload == 0)
            {
				StartCoroutine(SetupRoutine());

				done = true;
            }

			if (coinsToUload != 0)
            {
				LootLockerSDKManager.SubmitScore(playerID, coinsToUload, leaderboardID, (response) =>
				{
					if (response.success)
					{
						if (response.score < coinsToUload)
							response.score = coinsToUload;

						done = true;
					}

					else
					{
						Debug.Log(response.Error);

						done = true;
					}
				});

				StartCoroutine(SetupRoutine());
			}


			yield return new WaitWhile(() => done == false);
        }

        [System.Obsolete]
        public IEnumerator FetchTopHighCoinsRoutine()
        {
			bool done = false;

			LootLockerSDKManager.GetScoreListMain(leaderboardID, 5, 0, (response) =>
			{
				if (response.success)
				{
					string tempPlayerNames = "";
					string tempPlayerCoins = "";

					LootLockerLeaderboardMember[] members = response.items;

					for (int i = 0; i < members.Length; i++)
					{
						tempPlayerNames += $"{members[i].rank}. ";

						if (members[i].player.name != "")
							tempPlayerNames += members[i].player.name;

						else
							tempPlayerNames += members[i].player.id;

						tempPlayerCoins += $"{members[i].score}\n\n";
						tempPlayerNames += "\n\n";

						resultSet.usernames.text = tempPlayerNames;
						resultSet.highCoins.text = tempPlayerCoins;
					}

					done = true;
				}

				else
				{
					Debug.Log(response.Error);

					done = true;
				}
			});

			yield return new WaitWhile(() => done == false);
        }

        [System.Obsolete]
        public IEnumerator FetchCurrentPlayerHighCoinsRoutine()
        {
			bool done = false;
			string currentPlayerID = PlayerPrefs.GetString("PlayerID");

			LootLockerSDKManager.GetMemberRank(leaderboardID, currentPlayerID, (response) =>
			{
				if (response.success)
                {
					resultSet.currentUsername.text = $"{response.rank}. {response.player.name}";
					resultSet.currentHighCoins.text = $"{response.score}";

					done = true;
				}

				else
				{
					Debug.Log(response.Error);

					done = true;
				}
			});

			yield return new WaitWhile(() => done == false);
		}
	}
}