using Enums;
using UnityEngine;

namespace BoxObject
{
    public class BoxTemplate : MonoBehaviour
    {
        [SerializeField] private BoosterNames _boosterNames;

        public BoosterNames BoosterNames => _boosterNames;
    }
}