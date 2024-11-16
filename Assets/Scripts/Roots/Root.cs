using PlayerLogic;
using SaveLogic;
using UnityEngine;

namespace Roots
{
    [RequireComponent(typeof(SaveService), typeof(Wallet))]
    public abstract class Root : MonoBehaviour
    {
        protected SaveService SaveService { get; private set; }

        protected Wallet Wallet { get; private set; }

        private void Awake()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        Agava.YandexGames.YandexGamesSdk.GameReady();
#endif
            SaveService = GetComponent<SaveService>();
            Wallet = GetComponent<Wallet>();
        }

        private void OnEnable()
        {
            SaveService.Loaded += OnInit;
        }

        private void OnDisable()
        {
            SaveService.Loaded -= OnInit;
        }

        protected abstract void OnInit();
    }
}