using Agava.WebUtility;
using UnityEngine;

namespace UI
{
    public class FocusTracking : MonoBehaviour
    {
        private const int MinValue = 0;
        private const int MaxValue = 1;

        private void Awake()
        {
            Time.timeScale = MaxValue;
            AudioListener.pause = false;
            AudioListener.volume = MaxValue;
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

        private void MuteAudio(bool value) => AudioListener.pause = value;

        private void PauseGame(bool value) => Time.timeScale = value ? MinValue : MaxValue;
    }
}