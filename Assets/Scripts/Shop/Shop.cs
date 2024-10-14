using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Template[] _templates;
    [SerializeField] private ProductView productView;
    [SerializeField] private PanelTyepProducts _panelCreateBallProducts;
    [SerializeField] private PanelTyepProducts _panelCreatePlatformProducts;
    [SerializeField] private SaveService _saveService;

    private void OnEnable()
    {
        _saveService.Loaded += Create;
    }

    private void OnDisable()
    {
        _saveService.Loaded -= Create;
    }

    private void Create()
    {
        _templates = _templates.OrderBy(template => template.Price).ToArray();

        foreach (var template in _templates)
        {
            if (template.ObjectsName == Enums.ObjectsName.Ball)
                _panelCreateBallProducts.Create(productView, template);

            if (template.ObjectsName == Enums.ObjectsName.Platform)
                _panelCreatePlatformProducts.Create(productView, template);
        }

        _panelCreateBallProducts.Init(_saveService);
        _panelCreatePlatformProducts.Init(_saveService);
    }
}