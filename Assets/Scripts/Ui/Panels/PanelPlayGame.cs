using UnityEngine;

public class PanelPlayGame : Panel
{
    [SerializeField] private ButtonPlayGame _buttonPlayGame;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private LocationCreateView _locationCreateView;
    [SerializeField] private SaveService _saveService;

    private LocationObject _locationObject;

    public bool IsInit { get; private set; }

    public ButtonPanelInteraction ButtonClose => _buttonClose;

    public ButtonPlayGame ButtonPlayGame => _buttonPlayGame;

    private void OnEnable() => _buttonPlayGame.Clicked += OnClick;

    private void OnDisable() => _buttonPlayGame.Clicked -= OnClick;

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
        _locationCreateView.gameObject.SetActive(isActive);
    }

    public void Init(LocationObject locationObject)
    {
        IsInit = false;
        _locationObject = locationObject;

        if (_locationObject.IsActive == true) IsInit = true;
    }

    private void OnClick() => _saveService.SaveCurrentLocationName(_locationObject.Name.ToString());
}