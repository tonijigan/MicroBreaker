using System;
using UnityEngine;

public class PanelPlayGame : Panel
{
    [SerializeField] private ButtonPlayGame _buttonPlayGame;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private LocationChooseInput _locationChooseInput;

    public bool IsInit { get; private set; }

    public ButtonPanelInteraction ButtonClose => _buttonClose;

    public void Init(LocationObject locationObject)
    {
        IsInit = false;
        _buttonPlayGame.Init(locationObject);

        if (locationObject.IsActive == true)
            IsInit = true;
    }
}