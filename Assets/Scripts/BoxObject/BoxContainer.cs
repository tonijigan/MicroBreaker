using UnityEngine;
using Boosters;
using Enums;

namespace BoxObject
{
    public class BoxContainer : MonoBehaviour
    {
        [SerializeField] private Transform _path;
        [SerializeField] private BoostersContainer _boosterContainer;
        [SerializeField] private ParticleSystem _particleSystem;

        private Box[] _boxes;

        private void Awake()
        {
            // _boosterContainer.Create();
            Fill();
        }

        private void Fill()
        {
            _boxes = new Box[_path.childCount];

            for (int i = 0; i < _boxes.Length; i++)
            {
                if (_path.GetChild(i).TryGetComponent(out Box box))
                {
                    Booster booster = _boosterContainer.CreateBoosters(box.BoosterName);
                    _boxes[i] = box;
                    _boxes[i].Init(booster, _particleSystem);

                    Debug.Log($"{booster.ObjectName}  {booster.BoosterName}");
                    //FillBoxesType(box, _boxes[i], BoosterNames.Positive);
                    //FillBoxesType(box, _boxes[i], BoosterNames.Negative);
                    //FillBoxesType(box, _boxes[i], BoosterNames.Default);
                }
            }
        }

        //private void FillBoxesType(Box box, Box currentBox, BoosterNames boxName)
        //{
        //    Booster[] boosters = _boosterContainer.GetBoostersType(box.BoosterName);
        //    currentBox = box;

        //    Debug.Log(booster.BoosterName);
        //    currentBox.Init(booster, _particleSystem);
        //    booster.gameObject.SetActive(false);
        //}
    }
}