using BallObject;
using PlatformObject;
using System;
using UnityEngine;

public class TriggerLoss : MonoBehaviour
{
    [SerializeField] private Platform _platform;

    public event Action Lost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.gameObject.SetActive(false);
            _platform.Die();
            Lost?.Invoke();
        }
    }
}