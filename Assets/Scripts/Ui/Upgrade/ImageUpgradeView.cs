using Enums;
using UnityEngine;
using UnityEngine.UI;

public class ImageUpgradeView : MonoBehaviour
{
    [SerializeField] private ObjectsName _objectsName;
    [SerializeField] private UpgradeName _upgradeName;
    [SerializeField] private Sprite _sprite;

    public ObjectsName ObjectsName => _objectsName;

    public UpgradeName UpgradeName => _upgradeName;

    public Sprite Sprite => _sprite;
}