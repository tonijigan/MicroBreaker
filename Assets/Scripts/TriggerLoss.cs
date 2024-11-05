using BallObject;
using PlatformObject;
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerLoss : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private Ball _ball;

    public event Action Lost;

    private Collider _collider;

    public Collider Collider => _collider;

    private void Awake() => _collider = GetComponent<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            if (ball.name == _ball.name)
            {
                ball.gameObject.SetActive(false);
                _platform.Die();
                Lost?.Invoke();
            }

            ball.gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out AbstractBooster booster))
        {
            booster.gameObject.SetActive(false);
        }
    }
}