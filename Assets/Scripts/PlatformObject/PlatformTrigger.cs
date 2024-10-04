using Boosters;
using System;
using UnityEngine;
using Enums;

namespace PlatformObject
{
    public class PlatformTrigger : MonoBehaviour
    {
        public event Action<Booster, ObjectsName> BoosterSended;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Booster booster))
            {
                Debug.Log($"{booster.ObjectName} , {booster.BoosterName}");
                if (booster.ObjectName == ObjectsName.Ball)
                    BoosterSended?.Invoke(booster, ObjectsName.Ball);

                if (booster.ObjectName == ObjectsName.Platform)
                    BoosterSended?.Invoke(booster, ObjectsName.Platform);

                booster.gameObject.SetActive(false);
            }
        }
    }
}