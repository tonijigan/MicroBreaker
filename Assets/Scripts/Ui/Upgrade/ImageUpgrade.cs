using Enums;
using UnityEngine;
using UnityEngine.UI;

public class ImageUpgrade : MonoBehaviour
{
    [SerializeField] private UpgradeName _upgradeName;
    [SerializeField] private Sprite _sprite;

    public UpgradeName UpgradeName => _upgradeName;

    public Sprite Sprite => _sprite;
}