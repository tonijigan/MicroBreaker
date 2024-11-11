using Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Boosters
{
    public class BoostersContainer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private List<AbstractBooster> _boosters;
        private Transform _transform;

        public List<AbstractBooster> AbstractBoosters => _boosters;

        public void Fill()
        {
            _transform = transform;
            _boosters = new List<AbstractBooster>();

            for (int i = 0; i < _transform.childCount; i++)
            {
                _transform.GetChild(i).TryGetComponent(out AbstractBooster booster);
                _boosters.Add(booster);
                _boosters[i].TimeRunning += PlaySound;
            }
        }

        private void OnDisable()
        {
            foreach (var booster in _boosters)
                booster.TimeRunning -= PlaySound;
        }

        public BoosterEffect GetRandomBoosters(BoosterNames boxName)
        {
            int minLength = 0;
            var booster = _boosters.Where(booster => booster.BoosterName == boxName && booster.BoosterEffect.IsCreated == false)
                                   .Select(booster => booster).ToList();

            if (booster.Count == 0) return null;

            int index = _boosters.IndexOf(booster[Random.Range(minLength, booster.Count)]);
            _boosters[index].BoosterEffect.HaveCreated();
            return _boosters[index].BoosterEffect;
        }

        public void Reset()
        {
            foreach (var booster in _boosters)
                booster.StopAction(booster.BoosterEffect);
        }

        private void PlaySound()
        {
            if (_audioSource.isPlaying)
                _audioSource.Stop();

            _audioSource.Play();
        }
    }
}