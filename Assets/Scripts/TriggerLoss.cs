using BallObject;
using Boosters;
using PlatformObject;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerLoss : MonoBehaviour
{
    private const float WaitSeconds = 1.5f;

    [SerializeField] private Platform _platform;
    [SerializeField] private Ball _ball;
    [SerializeField] private BoostersContainer _boostersContainer;

    public event Action Lost;

    private Collider _collider;
    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    public Collider Collider => _collider;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(WaitSeconds);
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            if (ball.name == _ball.name)
            {
                ball.Die();
                _platform.Die();
                _boostersContainer.Reset();
                TryGiveExtraLive();
            }

            ball.gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out AbstractBooster booster))
        {
            booster.gameObject.SetActive(false);
        }
    }

    private void TryGiveExtraLive()
    {
        if (_ball.ExtraLive <= 0)
        {
            Lost?.Invoke();
            return;
        }

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(TakeExtraLive());
    }

    private IEnumerator TakeExtraLive()
    {
        yield return _waitForSeconds;
        _platform.GiveLive();
        _ball.GiveLive();
        StopCoroutine(_coroutine);
    }
}