using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(ProductTypeSection), typeof(SwipePanel))]
public class PanelDisplayAllPlatformProducts : MonoBehaviour
{
    [SerializeField] private Transform _currentTemplatePoint;
    [SerializeField] private Transform _oldTransform;
    [SerializeField] private Transform _currentTransform;
    [SerializeField] private Transform _nextTransform;

    private SwipePanel _swipePanel;
    private PanelProduct _panelProduct;
    private ProductTypeSection _productTypeSection;
    private readonly List<Template> _platformTemplates = new();
    private int _currentIndex = 0;
    private Template _currentTemplate;
    private Tween _rotateTween;

    private void Awake()
    {
        _productTypeSection = GetComponent<ProductTypeSection>();
        _swipePanel = GetComponent<SwipePanel>();
    }

    private void OnEnable()
    {
        _productTypeSection.Inited += Create;
        _swipePanel.Swiped += OnSetCurrentPlatform;
    }

    private void OnDisable()
    {
        _productTypeSection.Inited -= Create;
        _swipePanel.Swiped -= OnSetCurrentPlatform;
    }

    public void Create(List<Product> products, PanelProduct panelProduct)
    {
        _panelProduct = panelProduct;

        for (int i = 0; i < products.Count; i++)
        {
            _platformTemplates.Add(Instantiate(products[i].Template, _currentTemplatePoint));
            _platformTemplates[i].transform.DOScale(new Vector3(10, 10, 10), 0);
        }

        OnSetCurrentPlatform(_currentIndex);
    }

    private void OnSetCurrentPlatform(int element)
    {
        foreach (var template in _platformTemplates)
            template.gameObject.SetActive(false);

        _currentTemplate = _platformTemplates[GetCurrentIndex(element)];
        _currentTemplate.gameObject.SetActive(true);
        MoveChangePlatform();
    }

    private void MoveChangePlatform()
    {
        if (_currentIndex > 0)
        {
            _platformTemplates[_currentIndex - 1].gameObject.SetActive(true);
            _platformTemplates[_currentIndex - 1].transform.position = _oldTransform.position;
        }

        _currentTemplate.transform.position = _currentTransform.position;
        PlatformRotate();

        if (_currentIndex < _platformTemplates.Count - 1)
        {
            _platformTemplates[_currentIndex + 1].gameObject.SetActive(true);
            _platformTemplates[_currentIndex + 1].transform.position = _nextTransform.position;
        }
    }

    private async void PlatformRotate()
    {
        await RotateMove();
    }

    public async Task RotateMove()
    {
        await _currentTemplate.transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.FastBeyond360).
                                 SetLoops(-1).SetRelative().SetEase(Ease.Linear).AsyncWaitForCompletion();
    }

    private int GetCurrentIndex(int element)
    {
        int newIndex = _currentIndex + element;

        if (newIndex < 0)
            return _currentIndex;

        if (newIndex >= _platformTemplates.Count - 1)
            return _currentIndex = _platformTemplates.Count - 1;

        return _currentIndex = newIndex;
    }
}