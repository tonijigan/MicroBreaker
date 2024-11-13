using DG.Tweening;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class BoosterView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Init(Sprite sprite, BoosterNames boosterNames)
    {
        _image.sprite = sprite;
        _image.DOFade(1, 1);
        SetColor(boosterNames);
        _image.DOFade(0, 3);
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