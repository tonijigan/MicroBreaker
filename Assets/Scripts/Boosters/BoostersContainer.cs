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
                Debug.Log(_boosters.Count);
            }
        }

        public BoosterEffect GetRandomBoosters(BoosterNames boxName)
        {
            int minLength = 0;
            var booster = _boosters.Where(booster => booster.BoosterName == boxName && booster.BoosterEffect.IsCreated == false)
                                   .Select(booster => booster).ToList();

            if (booster.Count == 0)
            {
                return null;
            }
            BoosterEffect boosterEffect = booster[Random.Range(minLength, booster.Count)].BoosterEffect;
            boosterEffect.HaveCreated();
            return boosterEffect;
        }
    }
}