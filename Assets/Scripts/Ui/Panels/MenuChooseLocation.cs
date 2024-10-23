using Cinemachine;
using UnityEngine;

public class MenuChooseLocation : MonoBehaviour
{
    [SerializeField] private PanelPlayGame _panelPlayGame;
    [SerializeField] private PanelShop _panelShop;
    [SerializeField] private LocationChooseInput _locationChooseInput;
    [SerializeField] private SwipeMove _swipeMove;
    [SerializeField] private CinemachineVirtualCamera _virtualMobileCamera;

    private void OnEnable()
    {
        _panelShop.Activated += OnActive;
        _locationChooseInput.LocationChoosed += OnInit;
        _panelPlayGame.ButtonClose.Clicked += OnActivateControl;
        _panelPlayGame.ButtonPlayGame.Clicked += () =>
        {
            _virtualMobileCamera.gameObject.SetActive(true);
            _virtualMobileCamera.Priority = 1;
        };
    }

    private void OnDisable()
    {
        _panelShop.Activated -= OnActive;
        _locationChooseInput.LocationChoosed -= OnInit;
        _panelPlayGame.ButtonClose.Clicked -= OnActivateControl;
        _panelPlayGame.ButtonPlayGame.Clicked += () =>
        {
            _virtualMobileCamera.gameObject.SetActive(true);
            _virtualMobileCamera.Priority = 1;
        };
    }

    private void OnInit(LocationObject locationObject)
    {
        _virtualMobileCamera.transform.position = new Vector3(_virtualMobileCamera.transform.position.x, _virtualMobileCamera.transform.position.y,
          locationObject.transform.position.z - 20);
        _panelPlayGame.ButtonClose.SetStartStateButton();
        _panelPlayGame.Move(true);
        _panelPlayGame.Init(locationObject);
        OnActivateControl(true);
    }

    private void OnActive(bool isActive)
    {
        OnActivateControl(isActive);

        _panelPlayGame.Move(false);

        if (_panelShop.IsActive == false && _panelPlayGame.IsInit == true && _panelPlayGame.ButtonClose.IsClick == false)
        {
            _panelPlayGame.Move(true);
            OnActivateControl(true);
        }
    }

    private void OnActivateControl(bool isActive)
    {
        _locationChooseInput.SetActive(!isActive);
        _swipeMove.enabled = !isActive;
    }
}