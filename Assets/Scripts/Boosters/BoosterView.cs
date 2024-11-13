using Enums;
using UnityEngine;
using UnityEngine.UI;

public class BoosterView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Init(Sprite sprite, BoosterNames boosterNames)
    {
        _image.sprite = sprite;
        SetColor(boosterNames);
    }

    private void SetColor(BoosterNames boosterNames)
    {
        if (boosterNames == BoosterNames.Positive)
            _image.color = Color.blue;

        if (boosterNames == BoosterNames.Negative)
            _image.color = Color.red;

        if (boosterNames == BoosterNames.Default)
            _image.color = Color.red + Color.blue;
    }
}