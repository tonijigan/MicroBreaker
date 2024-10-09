using UnityEngine;

public class PanelPlayGame : Panel
{
    [SerializeField] private ButtonPlayGame _buttonPlayGame;
    [SerializeField] private LocationChooseInput _locationChooseInput;

    public ButtonPlayGame ButtonPlayGame => _buttonPlayGame;

    public void Init(LocationObject locationObject)
    {
        _buttonPlayGame.Init(locationObject);
    }
}