using UnityEngine;

namespace BallsComing.Balls.Rolling
{
	public class BallsRoll : MonoBehaviour
	{
        private bool ExcludingOriginals => OriginalBallsCheck();

        [SerializeField] float speed = 5f;
        [SerializeField] float speedAddition = 2f;

        private static GameObject[] originalBallsArr;

        private void Awake()
        {
            SetOriginalBallsArray();
        }

        private static void SetOriginalBallsArray()
        {
            Transform originalBallsTr = GameObject.Find("Balls Original Rolling").transform;

            int originalBallsArrLength = originalBallsTr.childCount;
            originalBallsArr = new GameObject[originalBallsArrLength];

            for (int i = 0; i < originalBallsArrLength; i++)
                originalBallsArr[i] = originalBallsTr.GetChild(i).gameObject;
        }

        private bool OriginalBallsCheck()
        {
            try
            {
                return gameObject.name != originalBallsArr[0].name && gameObject.name != originalBallsArr[1].name && gameObject.name != originalBallsArr[2].name;
            }
            catch
            {
                return true;
            }
        }

        private void Update()
        {
            if (ExcludingOriginals) Roll();
        }

        private void Roll()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }

        public void UpgradeSpeed()
        {
            speed += speedAddition;
        }
    }
}