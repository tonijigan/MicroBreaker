using Agava.WebUtility;
using UnityEngine;

public class FocusTracking : MonoBehaviour
{
    private int _minValue = 0;
    private int _maxValue = 1;

    private void Awake()
    {
        Time.timeScale = _maxValue;
        AudioListener.pause = false;
        AudioListener.volume = _maxValue;
    }

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    private void OnInBackgroundChangeApp(bool inApp)
    {
        MuteAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWeb(bool inBackground)
    {
        MuteAudio(inBackground);
        PauseGame(inBackground);
    }

    private void MuteAudio(bool value)
    {
        AudioListener.pause = value;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? _minValue : _maxValue;
    }

}