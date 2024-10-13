using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    private Template _template;
    private Image _image;
    private int _price;


    public Template Template => _template;

    public Image Image => _image;

    public int Price => _price;

    public bool IsBuying { get; private set; } = false;

    public void Init(Template template, Image image, int price)
    {
        _template = template;
        _image = image;
        _price = price;
    }

    public void Buy()
    {
        IsBuying = true;
    }
}