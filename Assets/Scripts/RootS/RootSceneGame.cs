using PlayerObject;
using UnityEngine;

[RequireComponent(typeof(SaveService))]
public class RootSceneGame : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private LocationCreate _locationCreate;

    private SaveService _saveService;

    private void Awake()
    {
        _saveService = GetComponent<SaveService>();
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
        _locationCreate.Init(_saveService.CurrentLocationName);
    }
}
