public class RootSceneChooseLocation : Root
{
    protected override void OnInit()
    {
        _wallet.Init(_saveService.Coins);
    }
}