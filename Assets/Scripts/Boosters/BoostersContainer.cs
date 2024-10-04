using Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Boosters
{
    public class BoostersContainer : MonoBehaviour
    {
        [SerializeField] private List<Booster> _boosters;

        public Booster CreateBoosters(BoosterNames boosterNames)
        {
            Booster booster = Instantiate(GetRandomBoostersType(boosterNames), transform);
            _boosters.Add(booster);
            booster.gameObject.SetActive(false);
            return booster;
        }

        private Booster GetRandomBoostersType(BoosterNames boxName)
        {
            int minLength = 0;
            var booster = _boosters.Where(booster => booster.BoosterName == boxName).Select(booster => booster).ToList();
            return booster[Random.Range(minLength, booster.Count)];
        }
    }
}