using TMPro;
using UnityEngine;

public class PanelPlayGame : Panel
{
    private const string Access = "IS NOT ACCESS";

    [SerializeField] private ButtonPlayGame _buttonPlayGame;
    [SerializeField] private ButtonPanelInteraction _buttonClose;
    [SerializeField] private ButtonUpgrade _firstButtonUpgrade;
    [SerializeField] private ButtonUpgrade _secondButtonUpgrade;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private LocationCreateView _locationCreateView;
    [SerializeField] private SaveService _saveService;
    [SerializeField] private TMP_Text _textAccess;
    [SerializeField] private TMP_Text _textName;

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
        _textName.text = locationObject.Name.ToString();

        if (_locationObject.IsActive == false)
        {
            SetAccess(false);
            return;
        }

        SetAccess(true);
        IsInit = true;
    }

    private void SetAccess(bool isAccess)
    {
        _firstButtonUpgrade.gameObject.SetActive(isAccess);
        _secondButtonUpgrade.gameObject.SetActive(isAccess);
        _buttonPlayGame.gameObject.SetActive(isAccess);
        _textAccess.gameObject.SetActive(!isAccess);
        _textAccess.color = Color.red;
        _textAccess.text = Access;
    }

    private void OnClick() => _saveService.SaveCurrentLocationName(_locationObject.Name.ToString());
}