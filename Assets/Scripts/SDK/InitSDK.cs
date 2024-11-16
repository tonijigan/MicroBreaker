using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDK
{
    public sealed class InitSDK : MonoBehaviour
    {
        private void Awake() => YandexGamesSdk.CallbackLogging = true;

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialised);
        }

        private void OnInitialised()
        {
            SceneManager.LoadScene(Enums.ScenesName.StartScene.ToString());
        }
    }
}