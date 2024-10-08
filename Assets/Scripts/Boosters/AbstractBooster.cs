using Boosters;
using Enums;
using UnityEngine;

public abstract class AbstractBooster : MonoBehaviour
{
    [SerializeField] private BoosterNames _boosterName;
    [SerializeField] private BoosterEffect _boosterEffect;

    public BoosterEffect BoosterEffect { get; private set; }

    public BoosterNames BoosterName => _boosterName;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        BoosterEffect = Instantiate(_boosterEffect, _transform);
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

    protected abstract void OnStartAction();
}