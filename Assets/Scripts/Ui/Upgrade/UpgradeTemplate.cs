using Enums;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTemplate : MonoBehaviour
{
    [SerializeField] private UpgradeName _upgradeName;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _description;
    [SerializeField] private int _firstPrice;
    [SerializeField] private int _secondprice;
    [SerializeField] private int _thirdPrice;

    public UpgradeName UpgradeName => _upgradeName;

    public Sprite Sprite => _sprite;

    public string Description => _description;

    public int FirstPrice => _firstPrice;

    public int SecondPrice => _secondprice;

    public int ThirdPrice => _thirdPrice;
}