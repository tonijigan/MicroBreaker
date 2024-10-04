using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class InitSDK : MonoBehaviour
{
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        YandexGamesSdk.GameReady();
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnInitialised);
    }

    private void OnInitialised()
    {
        SceneManager.LoadScene("Game1");
    }
}