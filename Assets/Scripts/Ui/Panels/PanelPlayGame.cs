using Cinemachine;
using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class PanelPlayGame : Panel
{
    [SerializeField] private ButtonPlayGame _buttonPlayGame;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private LocationCreateView _locationCreateView;

    public bool IsInit { get; private set; }

    public ButtonPanelInteraction ButtonClose => _buttonClose;

    public ButtonPlayGame ButtonPlayGame => _buttonPlayGame;

    private void OnEnable()
    {
        _buttonPlayGame.Clicked += () => { Move(false); };
    }

    private void OnDisable()
    {
        _buttonPlayGame.Clicked -= () => { Move(false); };
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