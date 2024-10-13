using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ProductObject[] _productObjects;
    [SerializeField] private PanelBallProducts _panelBallProducts;
    [SerializeField] private PanelPlatformProducts _panelPlatformProducts;
    [SerializeField] private SaveService _saveService;

    private void OnEnable()
    {
        _saveService.Loaded += OnSortPrudoct;
    }

    private void OnDisable()
    {
        _saveService.Loaded += OnSortPrudoct;
    }

    private void OnSortPrudoct()
    {

    }
}