using Boosters;
using System;
using UnityEngine;
using Enums;

namespace PlatformObject
{
    public class PlatformTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out BoosterEffect booster))
            {
                booster.PlayAction();
                booster.gameObject.SetActive(false);
            }
        }
    }
}