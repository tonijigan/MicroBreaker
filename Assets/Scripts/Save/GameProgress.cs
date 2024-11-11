public class GameProgress
{
    public int Coins = 0;
    public int LevelCount = 1;
    public int ScaleBall = 0;
    public int ScalePlatform = 0;
    public string CurrentLocationName = string.Empty;
    public string CurrentBall = string.Empty;
    public string CurrentPlatform = string.Empty;
    public string[] Balls = null;
    public string[] Platforms = null;
    public string[] LocationNames = null;
    public LocationObjectData[] LocationObjectAccess = null;
    public UpgradeData[] UpgradeSave = null;
}