using Enums;
using Interfaces;
using UnityEngine;

namespace BallObject
{
    public class BallEffect : MonoBehaviour, IEffect
    {
        [SerializeField] private ParticleSystem _effectDefult;
        [SerializeField] private ParticleSystem _effectNegayive;
        [SerializeField] private ParticleSystem _effectPositive;

        private ParticleSystem _currentParticleSystem;

        private void Awake()
        {
            _effectDefult.Stop();
            _effectNegayive.Stop();
            _effectPositive.Stop();
            _currentParticleSystem = _effectDefult;
        }

        public void Play(Vector3 point) { }

        public void RotateTarget(Vector3 direction) => transform.LookAt(-direction);

        public void SetParticleSystem(BoosterNames boosterNames)
        {
            _currentParticleSystem.Stop();

            if (boosterNames == BoosterNames.Default) _currentParticleSystem = _effectDefult;
            if (boosterNames == BoosterNames.Negative) _currentParticleSystem = _effectNegayive;
            if (boosterNames == BoosterNames.Positive) _currentParticleSystem = _effectPositive;

            _currentParticleSystem.Play();
        }
    }
}