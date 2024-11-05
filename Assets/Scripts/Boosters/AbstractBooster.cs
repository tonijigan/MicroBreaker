using Boosters;
using Enums;
using UnityEngine;

public abstract class AbstractBooster : MonoBehaviour
{
    [SerializeField] private BoosterNames _boosterName;
    [SerializeField] private BoosterEffect _boosterEffect;

    public BoosterEffect BoosterEffect { get; private set; }

    public BoosterNames BoosterName => _boosterName;

    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
        BoosterEffect = Instantiate(_boosterEffect, Transform);
        BoosterEffect.gameObject.SetActive(false);
    }

    private void OnEnable() => BoosterEffect.Collided += OnStartAction;

    private void OnDisable() => BoosterEffect.Collided -= OnStartAction;

    public abstract void OnStartAction(BoosterEffect boosterEffect);

    public abstract void StopAction(BoosterEffect boosterEffect);
}