using PlayerObject;
using UnityEngine;

[RequireComponent(typeof(SaveService), typeof(Wallet))]
public class RootSceneChooseLocation : MonoBehaviour
{
    private SaveService _saveService;
    private Wallet _wallet;

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

    private void OnInit()
    {
        _wallet.Init(_saveService.Coins);
    }
}