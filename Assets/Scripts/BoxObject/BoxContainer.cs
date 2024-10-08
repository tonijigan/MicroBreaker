using UnityEngine;
using Boosters;

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
            boosterContainer.Fill();

            for (int i = 0; i < _boxes.Length; i++)
            {
                if (_transform.GetChild(i).TryGetComponent(out Box box))
                {
                    BoosterEffect booster = boosterContainer.GetRandomBoosters(box.BoosterName);
                    _boxes[i] = box;

                    if (booster == null)
                        _boxes[i].Init(_particleSystem);
                    else
                        _boxes[i].Init(booster, _particleSystem);
                }
            }
        }
    }
}