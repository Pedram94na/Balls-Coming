using UnityEngine;
using UnityEngine.Events;

using System.Collections;

using BallsComing.Interactable.Balls.BallsData;
using BallsComing.Core;

namespace BallsComing.Balls
{
	public class BallsDespawner : MonoBehaviour
	{
        private bool ExcludingOriginals => OriginalBallsCheck();
        private bool OriginalBallsCheck()
        {
            try
            {
                return gameObject != originalBallsArr[0] && gameObject != originalBallsArr[1] && gameObject != originalBallsArr[2] && gameObject != originalBallsArr[3];
            }
            catch
            {
                return true;
            }
        }

        private InvincibilityEffect playerPowerUpEffects;

        private BallsParent ball;

        [SerializeField] private UnityEvent GameOverEv;

        private GameObject ballsOriginal;

        private static GameObject[] originalBallsArr;

        private GameObject player;
        private GameObject playerGFX;
        private ParticleSystem playerExplosionEffect;

        private void Awake()
        {
            playerPowerUpEffects = GameObject.Find("Game Manager").GetComponent<InvincibilityEffect>();

            GetBallInstance();

            SetOriginalBallsArray();

            ballsOriginal = GameObject.Find("Balls Original");

            player = GameObject.Find("Player");
            playerGFX = player.transform.GetChild(0).gameObject;
            playerExplosionEffect = player.transform.GetChild(1).GetComponent<ParticleSystem>();
        }

        private static void SetOriginalBallsArray()
        {
            Transform originalBallsTr = GameObject.Find("Balls Original").transform;

            int originalBallsArrLength = originalBallsTr.childCount;
            originalBallsArr = new GameObject[originalBallsArrLength];

            for (int i = 0; i < originalBallsArrLength; i++)
                originalBallsArr[i] = originalBallsTr.GetChild(i).gameObject;
        }

        private void GetBallInstance()
        {
            ball = name.Split(" ")[0] switch
            {
                "Red" => RedBall.GetInstance(),

                "Green" => GreenBall.GetInstance(),

                "Yellow" => YellowBall.GetInstance(),

                "Blue" => BlueBall.GetInstance(),

                _ => null,
            };
        }

        private void Start()
        {
            playerExplosionEffect.Stop();
        }

        private void Update()
        {
            if (GetPlayerPowerupsStats() == 2 && ExcludingOriginals) Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (GetIsFallingBall() && collision.gameObject.CompareTag("Ground")) Destroy(gameObject);

            if (collision.gameObject.CompareTag("Player"))
            {
                int i = GetPlayerPowerupsStats();
                switch (i)
                {
                    case 0:
                    case 3:
                        StartCoroutine(PlayerExplosion());

                        break;

                    case 1:
                        Destroy(gameObject);

                        break;

                    case 2:
                    default:
                        break;
                }
            }
        }

        private IEnumerator PlayerExplosion()
        {
            playerPowerUpEffects.RestoreOriginalTexture();

            playerGFX.SetActive(false);

            playerExplosionEffect.Play();
            
            GameOverEv.Invoke();

            yield return new WaitForSeconds(1f);
            
            Destroy(player);

            Destroy(ballsOriginal);
        }

        #region Getters
        private bool GetIsFallingBall() { return ball.IsFallingBall(); }

        private int GetPlayerPowerupsStats() { return (int)GameManager.playerPowerUpsStats; }
        #endregion
    }
}