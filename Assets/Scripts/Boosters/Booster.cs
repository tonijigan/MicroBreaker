using Enums;
using UnityEngine;

namespace Boosters
{
    public class Booster : MonoBehaviour
    {
        private const float PositionZero = 0;
        private const float PositionZ = 1;

        [SerializeField] private float _speed;
        [SerializeField] private ObjectsName _objectName;
        [SerializeField] private BoosterNames _boosterName;

        public ObjectsName ObjectName => _objectName;
        public BoosterNames BoosterName => _boosterName;

        private void Update()
        {
            transform.Translate(new(PositionZero, PositionZero, -PositionZ * _speed * Time.deltaTime));
        }
    }
}