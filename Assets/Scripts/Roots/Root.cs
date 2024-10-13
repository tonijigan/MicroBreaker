using PlayerObject;
using UnityEngine;

[RequireComponent(typeof(SaveService), typeof(Wallet))]
public abstract class Root : MonoBehaviour
{
    protected SaveService _saveService;
    protected Wallet _wallet;

    private void Awake()
    {
        _saveService = GetComponent<SaveService>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnEnable()
    {
        _saveService.Loaded += OnInit;
    }

    private void OnDisable()
    {
        _saveService.Loaded -= OnInit;
    }

    protected abstract void OnInit();
}