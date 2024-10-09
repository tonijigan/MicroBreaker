using UnityEngine;

public class MenuChooseLocation : MonoBehaviour
{
    [SerializeField] private PanelPlayGame _panelPlayGame;
    [SerializeField] private PanelShop _panelShop;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private ButtonPanelInteraction[] _buttonClose;

    private void OnEnable()
    {
        _locationChooseInput.LocationChoosed += OnInit;

        for (int i = 0; i < _buttonClose.Length; i++)
        {
            _buttonClose[i].Clicked += SetActivePanelPlayGame;
        }
    }

    private void OnDisable()
    {
        _locationChooseInput.LocationChoosed -= OnInit;

        for (int i = 0; i < _buttonClose.Length; i++)
        {
            _buttonClose[i].Clicked -= SetActivePanelPlayGame;
        }
    }

    private void OnInit(LocationObject locationObject)
    {
        SetActivePanelPlayGame(true);
        _panelShop.OnMovePanel(false);
        _panelPlayGame.Init(locationObject);
    }

    private void SetActivePanelPlayGame(bool isActive)
    {
        _locationChooseInput.HaveLocation();
        _panelPlayGame.gameObject.SetActive(isActive);
    }
}