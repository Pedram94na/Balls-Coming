using UnityEngine;
using UnityEngine.Networking;

using System.Collections;
using System;


namespace BallsComing.ServerSide
{
    public class ItchIoAuth : MonoBehaviour
    {
        public static ItchIoAuth instance;

        //private readonly string apiKey = Environment.GetEnvironmentVariable("ITCHIO_API_KEY");
        private readonly string apiKey =  "qnJmdS46WtIVT9WpE4DpX9O4G7wfOO8SAcKda4tk";

        private const string userInfoEndpoint = "https://itch.io/api/1/jwt/me";

        public delegate void UsernameCallback(string username);

        private void Awake()
        {
            CreaingAnInstance();
        }

        private void CreaingAnInstance()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
                Destroy(gameObject);
        }

        public IEnumerator FetchItchUsername(UsernameCallback callback)
        {
            UnityWebRequest request = UnityWebRequest.Get(userInfoEndpoint);

            request.SetRequestHeader("Authorization", apiKey);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;

                UserInfoResponse userInfo = JsonUtility.FromJson<UserInfoResponse>(jsonResponse);
                string itchIoUsername = userInfo.username;
                
                Debug.Log($"API Response: {jsonResponse}");
                Debug.Log($"Username: {itchIoUsername} !");

                callback?.Invoke(itchIoUsername);
            }

            else
                Debug.LogError("Error making API request: " + request.error);
        }

        [System.Serializable]
        private class UserInfoResponse
        {
            public string username;
        }
    }
}