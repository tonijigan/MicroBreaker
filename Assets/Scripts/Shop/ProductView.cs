using TMPro;
using UnityEngine;

public class ProductView : AbstractButton
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private bool _canBuy;

    private PanelProduct _panelProduct;

    public string Name { get; private set; }

    public int Price { get; private set; }

    public bool IsBuy { get; private set; } = false;

    public bool CanBuy => _canBuy;

    public void Init(string name, int price, PanelProduct panel)
    {
        Name = name;
        Price = price;
        _name.text = name;
        _price.text = price.ToString();
        _panelProduct = panel;
        this.enabled = _canBuy;
    }

    public void SetCanBuy(bool canBuy)
    {
        _canBuy = canBuy;
        this.enabled = _canBuy;

        if (IsBuy == true)
        {
            _price.text = $"Buy ";
        }

        if (_canBuy == true)
            _price.text += $" {true}";
    }

    public void Buy()
    {
        IsBuy = true;
    }

    protected override void OnClick()
    {
        _panelProduct.gameObject.SetActive(true);
        _panelProduct.Init(this);
    }
}