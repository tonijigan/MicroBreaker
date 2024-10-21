using DG.Tweening;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

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
            _platformTemplates[i].transform.DOScale(new Vector3(13, 13, 13), 0);
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
        int element = 1;

        if (_currentIndex > 0)
            SetPlatformState(_platformTemplates[_currentIndex - element], _oldTransform);

        SetPlatformState(_currentTemplate, _currentTransform);
        PlatformRotate();

        if (_currentIndex < _platformTemplates.Count - element)
            SetPlatformState(_platformTemplates[_currentIndex + element], _nextTransform);
    }

    private void SetPlatformState(Template template, Transform needTransform)
    {
        template.gameObject.SetActive(true);
        template.transform.DOMove(needTransform.position, 0.5f);
        template.transform.localRotation = Quaternion.Euler(Vector3.zero);

    }

    private async void PlatformRotate()
    {
        if (_rotateTween != null && _rotateTween.IsPlaying() == true)
            _rotateTween.Kill();

        await RotateMove();
    }

    public async Task RotateMove()
    {
        _rotateTween = _currentTemplate.transform.DORotate(new Vector3(0, 360, 0), 5f, RotateMode.FastBeyond360).
                                 SetLoops(-1).SetRelative().SetEase(Ease.Linear);
        Task tween = _rotateTween.AsyncWaitForCompletion();
        await tween;
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