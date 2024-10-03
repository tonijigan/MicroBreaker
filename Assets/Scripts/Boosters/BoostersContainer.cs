using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoostersContainer : MonoBehaviour
{
    [SerializeField] private Booster[] _boosters;

    public Booster[] Boosters => _boosters;

    public void Create()
    {
        CreateBoosters();
    }

    public Booster[] GetBoostersType(BoxName boxName)
    {
        List<Booster> boosters = new();
        var boosts = _boosters.Where(booster => booster.Name == boxName).Select(booster => booster).ToList();
        return boosts.ToArray();
    }

    private void CreateBoosters()
    {
        for (int i = 0; i < _boosters.Length; i++)
        {
            Boosters[i] = Instantiate(_boosters[i], transform);
            Boosters[i].gameObject.SetActive(false);
        }
    }
}