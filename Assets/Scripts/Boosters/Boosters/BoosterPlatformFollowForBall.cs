using Boosters;
using PlatformObject;
using System.Collections;
using UnityEngine;

public class BoosterPlatformFollowForBall : AbstractBooster
{
    private const int Delay = 3;

    [SerializeField] private PlatformTrigger _platformTrigger;
    [SerializeField] private PlatformMovement _platformMovement;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private void Start() => _waitForSeconds = new WaitForSeconds(Delay);

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        SetAction(boosterEffect);
        StopCoroutine(_coroutine);
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _coroutine = StartCoroutine(Play(boosterEffect));
        boosterEffect.SetActionActive();
    }

    private IEnumerator Play(BoosterEffect boosterEffect)
    {
        SetAction(boosterEffect);
        yield return _waitForSeconds;
        SetAction(boosterEffect);
    }

    private void SetAction(BoosterEffect boosterEffect)
    {
        _platformTrigger.ChangeStateCollision();
        _platformMovement.ChangeTarget();
        boosterEffect.SetActionActive();
    }
}