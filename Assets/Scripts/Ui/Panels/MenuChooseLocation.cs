using UnityEngine;

public class MenuChooseLocation : MonoBehaviour
{
    [SerializeField] private PanelPlayGame _panelPlayGame;
    [SerializeField] private PanelShop _panelShop;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private SwipeMove _swipeMove;

    private void OnEnable()
    {
        _panelShop.Actived += OnActive;
        _locationChooseInput.LocationChoosed += OnInit;
        _panelPlayGame.ButtonClose.Clicked += OnActivateControl;
    }

    private void OnDisable()
    {
        _panelShop.Actived -= OnActive;
        _locationChooseInput.LocationChoosed -= OnInit;
        _panelPlayGame.ButtonClose.Clicked -= OnActivateControl;
    }

    private void OnInit(LocationObject locationObject)
    {
        _panelPlayGame.ButtonClose.SetStartStateButton();
        _panelPlayGame.SetActive(true);
        _panelPlayGame.Init(locationObject);
        OnActivateControl(true);
    }

    private void OnActive(bool isActive)
    {
        OnActivateControl(isActive);

        _panelPlayGame.SetActive(false);

        if (_panelShop.IsActive == false && _panelPlayGame.IsInit == true && _panelPlayGame.ButtonClose.IsClick == false)
        {
            _panelPlayGame.SetActive(true);
            OnActivateControl(true);
        }
    }

    private void OnActivateControl(bool isActive)
    {
        _locationChooseInput.SetActive(!isActive);
        _swipeMove.enabled = !isActive;
    }
}