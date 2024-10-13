using Boosters;
using System;
using UnityEngine;

namespace PlatformObject
{
    public class PlatformTrigger : MonoBehaviour
    {
        public event Action CoinTriggered;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out BoosterEffect booster))
            {
                if (booster.IsCoin == true)
                {
                    CoinTriggered?.Invoke();
                }

                booster.PlayAction();
                booster.gameObject.SetActive(false);
            }
        }
    }
}