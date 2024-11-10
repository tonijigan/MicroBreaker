public class UpgradeValue
{
    private const int MaxSelectValue = 1;
    private const int MinSelectValue = 0;

    public string UpgradeName { get; private set; }

    public int Value { get; private set; }

    public bool IsSelect { get; private set; }

    public UpgradeValue(string upgradeName, int value, int selectValue)
    {
        UpgradeName = upgradeName;
        Value = value;
        IsSelect = true ? selectValue == MaxSelectValue : selectValue == MinSelectValue;
    }

    public void SetSelect(bool isSelect)
    {
        IsSelect = isSelect;
    }

    public int GetSelectValue()
    {
        return IsSelect ? MaxSelectValue : MinSelectValue;
    }
}