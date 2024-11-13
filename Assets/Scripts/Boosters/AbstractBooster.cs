using Boosters;
using Enums;
using System;
using System.Collections;
using UnityEngine;

public abstract class AbstractBooster : MonoBehaviour
{
    private const float LastSecondsTime = 2;

    [SerializeField] private BoosterNames _boosterName;
    [SerializeField] private BoosterEffect _boosterEffect;
    [SerializeField] private Sprite _sprite;

    public event Action TimeRunning;
    public event Action<Sprite, BoosterNames> Played;

    private WaitForSeconds _waitForSeconds;

    public BoosterNames BoosterName => _boosterName;

    public BoosterEffect BoosterEffect { get; private set; }

    public Transform Transform { get; private set; }

    protected Coroutine Coroutine { get; private set; }

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(LastSecondsTime);
        Transform = transform;
        BoosterEffect = Instantiate(_boosterEffect, Transform);
        BoosterEffect.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        BoosterEffect.Collided += OnStartAction;
    }

    private void OnDisable()
    {
        BoosterEffect.Collided -= OnStartAction;
    }

    public abstract void OnStartAction(BoosterEffect boosterEffect);

    public abstract void StopAction(BoosterEffect boosterEffect);

    protected void PlayTimer(float waitTime, BoosterEffect boosterEffect, Action<BoosterEffect> callBack)
    {
        Played?.Invoke(_sprite, _boosterName);
        if (Coroutine != null)
            StopCoroutine(Coroutine);

        Coroutine = StartCoroutine(StartTimer(waitTime, boosterEffect, callBack));
    }

    private IEnumerator StartTimer(float waitTime, BoosterEffect boosterEffect, Action<BoosterEffect> callBack)
    {
        yield return new WaitForSeconds(waitTime);
        TimeRunning?.Invoke();
        yield return _waitForSeconds;
        Stopped?.Invoke();
        callBack?.Invoke(boosterEffect);
    }
}