using UnityEngine;
using Boosters;
using Enums;

namespace BoxObject
{
    public class BoxContainer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private Transform _transform;
        private Box[] _boxes;

        public void Fill(BoostersContainer boosterContainer)
        {
            _transform = transform;
            _boxes = new Box[_transform.childCount];

            for (int i = 0; i < _boxes.Length; i++)
            {
                if (_transform.GetChild(i).TryGetComponent(out Box box))
                {
                    Booster booster = boosterContainer.CreateBoosters(box.BoosterName);
                    _boxes[i] = box;
                    _boxes[i].Init(booster, _particleSystem);
                }
            }
        }
    }
}