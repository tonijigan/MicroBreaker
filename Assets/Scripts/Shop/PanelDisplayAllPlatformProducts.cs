using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(ProductTypeSection))]
public class PanelDisplayAllPlatformProducts : MonoBehaviour
{
    [SerializeField] private Transform _currentTemplatePoint;

    private PanelProduct _panelProduct;
    private ProductTypeSection _productTypeSection;
    private readonly List<Template> _platformTemplates = new();

    private void Awake() => _productTypeSection = GetComponent<ProductTypeSection>();

    private void OnEnable() => _productTypeSection.Inited += Create;

    private void OnDisable() => _productTypeSection.Inited -= Create;

    public void Create(List<Product> products, PanelProduct panelProduct)
    {
        _panelProduct = panelProduct;

        for (int i = 0; i < products.Count; i++)
        {
            _platformTemplates.Add(Instantiate(products[i].Template, _currentTemplatePoint));
            _platformTemplates[i].transform.DORotate(new Vector3(0, 0, 70), 0);
            _platformTemplates[i].transform.DOScale(new Vector3(15, 15, 15), 0);
            _platformTemplates[i].gameObject.SetActive(false);
        }

        _platformTemplates.First().gameObject.SetActive(true);
        PlatformRotate();
    }

    private async void PlatformRotate()
    {
        await RotateMove();
    }

    public async Task RotateMove()
    {
        await _platformTemplates.First().transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.FastBeyond360).
                                 SetLoops(-1).SetRelative().SetEase(Ease.Linear).AsyncWaitForCompletion();
    }
}