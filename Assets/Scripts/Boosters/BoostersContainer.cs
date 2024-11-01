using Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Boosters
{
    public class BoostersContainer : MonoBehaviour
    {
        private List<AbstractBooster> _booster;
        private Transform _transform;

        public void Fill()
        {
            _transform = transform;
            _booster = new List<AbstractBooster>();

            for (int i = 0; i < _transform.childCount; i++)
            {
                _transform.GetChild(i).TryGetComponent(out AbstractBooster booster);
                _booster.Add(booster);
            }
        }

        public BoosterEffect GetRandomBoosters(BoosterNames boxName)
        {
            int minLength = 0;
            var booster = _booster.Where(booster => booster.BoosterName == boxName && booster.BoosterEffect.IsCreated == false)
                                   .Select(booster => booster).ToList();

            if (booster.Count == 0) return null;

            int index = _booster.IndexOf(booster[Random.Range(minLength, booster.Count)]);
            _booster[index].BoosterEffect.HaveCreated();
            return _booster[index].BoosterEffect;
        }
    }
}