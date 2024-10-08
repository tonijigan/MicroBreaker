using Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Boosters
{
    public class BoostersContainer : MonoBehaviour
    {
        [SerializeField] private List<AbstractBooster> _boosters;

        private readonly List<BoosterEffect> _boosterEffects = new();

        public void Fill()
        {
            for (int i = 0; i < _boosters.Count; i++)
            {
                _boosterEffects.Add(_boosters[i].BoosterEffect);
            }
        }

        public BoosterEffect GetRandomBoosters(BoosterNames boxName)
        {
            int minLength = 0;
            var booster = _boosterEffects.Where(booster => booster.BoosterName == boxName).Select(booster => booster).ToList();

            if (booster.Count == 0)
            {
                return null;
            }

            return booster[Random.Range(minLength, booster.Count)];
        }
    }
}