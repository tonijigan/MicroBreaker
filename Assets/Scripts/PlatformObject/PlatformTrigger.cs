using System;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public event Action<Booster> BoosterSended;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Booster booster))
        {
            BoosterSended?.Invoke(booster);
            booster.gameObject.SetActive(false);
        }
    }
}