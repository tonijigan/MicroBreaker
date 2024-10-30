using Cinemachine;
using DG.Tweening;
using Enums;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlayGame : Panel
{
    [SerializeField] private ButtonPlayGame _buttonPlayGame;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private LocationCreateView _locationCreateView;
    [SerializeField] private Button _buttonAddScaleBall;
    [SerializeField] private Button _buttonAddScalePlatform;
    [SerializeField] private SaveService _saveService;

    public bool IsInit { get; private set; }

    public ButtonPanelInteraction ButtonClose => _buttonClose;

    public ButtonPlayGame ButtonPlayGame => _buttonPlayGame;

    private void OnEnable()
    {
        _buttonPlayGame.Clicked += () => { Move(false); };
        //
        _buttonAddScaleBall.onClick.AddListener(() =>
        { _saveService.SaveScale(true, ObjectsName.Ball); _buttonAddScaleBall.enabled = false; });
        _buttonAddScalePlatform.onClick.AddListener(() =>
        { _saveService.SaveScale(true, ObjectsName.Platform); _buttonAddScalePlatform.enabled = false; });
        //
    }

    private void OnDisable()
    {
        _buttonPlayGame.Clicked -= () => { Move(false); };
        //
        _buttonAddScaleBall.onClick.RemoveListener(() =>
        { _saveService.SaveScale(true, ObjectsName.Ball); _buttonAddScaleBall.enabled = false; });
        _buttonAddScalePlatform.onClick.RemoveListener(() =>
        { _saveService.SaveScale(true, ObjectsName.Platform); _buttonAddScalePlatform.enabled = false; });
        //
    }

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
        _locationCreateView.gameObject.SetActive(isActive);
    }

    public void Init(LocationObject locationObject)
    {
        IsInit = false;
        _buttonPlayGame.Init(locationObject);

        if (locationObject.IsActive == true)
            IsInit = true;
    }
}