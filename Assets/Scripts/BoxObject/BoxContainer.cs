using UnityEngine;
using Boosters;

namespace BoxObject
{
    public class BoxContainer : MonoBehaviour
    {
        private const float ParticleScale = 2;

        private ParticleSystem _particleSystem;
        private Transform _transform;
        private Box[] _boxes;

        public void Fill(BoostersContainer boosterContainer, ParticleSystem particleSystem)
        {
            _particleSystem = Instantiate(particleSystem, _transform);
            _particleSystem.transform.localScale = new Vector3(ParticleScale, ParticleScale, ParticleScale);
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