using UnityEngine;

namespace BallsComing.Balls.Falling
{
    public class BallsFallDown : MonoBehaviour
    {
        private bool ExcludingOriginals => OriginalBallsCheck();

        [SerializeField] float speed;
        [SerializeField] float speedAddition = 2f;

        private static GameObject[] originalBallsArr;

        private void Awake()
        {
            SetOriginalBallsArray();

            if (this.CompareTag("Ball1")) speed = 10f;
            if (this.CompareTag("Ball2")) speed = 5f;
            if (this.CompareTag("Ball3")) speed = 3f;
        }

        private static void SetOriginalBallsArray()
        {
            Transform originalBallsTr = GameObject.Find("Balls Original Falling").transform;

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
            if (ExcludingOriginals) Fall();
        }

        private void Fall()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }

        public void UpgradeSpeed()
        {
            speed += speedAddition;
        }
    }
}