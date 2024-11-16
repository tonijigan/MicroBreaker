using System.Collections.Generic;
using System.Linq;
using Enums;
using LocationLogic;
using UnityEngine;

namespace BoosterLogic.Boosters
{
    public class BoosterRandom : AbstractBooster
    {
        [SerializeField] private LocationCreate _locationCreate;

        private AbstractBooster _currentBooster;

        private void Start() => _locationCreate.Created += OnSetCurrenBooster;

        public override void StopAction(BoosterEffect boosterEffect) => _currentBooster.StopAction(boosterEffect);

        public override void OnStartAction(BoosterEffect boosterEffect) => _currentBooster.OnStartAction(boosterEffect);

        private void OnSetCurrenBooster(List<AbstractBooster> abstractBoosters)
        {
            List<AbstractBooster> boosters = abstractBoosters.Where(booster => booster.BoosterName == BoosterNames.Positive ||
                                                                    booster.BoosterName == BoosterNames.Negative).ToList();
            _currentBooster = boosters[Random.Range(0, boosters.Count)];
            _locationCreate.Created -= OnSetCurrenBooster;
        }
    }
}