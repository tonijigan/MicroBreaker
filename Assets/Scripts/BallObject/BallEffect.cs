using Enums;
using Interfaces;
using UnityEngine;

namespace BallObject
{
    public class BallEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private Transform _effectDefult;
        [SerializeField] private Transform _effectNegayive;
        [SerializeField] private Transform _effectPositive;

        private Transform _currentEffect;

        private void Awake() => SetParticleSystem(BoosterNames.Default);

        public void Play(Vector3 point) { }

        public void SetStateEffect(bool isPlay) => _currentEffect.gameObject.SetActive(isPlay);

        public void RotateTarget(Vector3 direction) => _currentEffect.transform.LookAt(-direction);

        public void SetParticleSystem(BoosterNames boosterNames)
        {
            _effectDefult.gameObject.SetActive(false);
            _effectNegayive.gameObject.SetActive(false);
            _effectPositive.gameObject.SetActive(false);

            if (boosterNames == BoosterNames.Default) _currentEffect = _effectDefult;
            if (boosterNames == BoosterNames.Negative) _currentEffect = _effectNegayive;
            if (boosterNames == BoosterNames.Positive) _currentEffect = _effectPositive;

            _currentEffect.gameObject.SetActive(true);
        }
    }
}