public class RootStartScene : Root
{
    protected override void OnInit()
    {
        _wallet.Init(_saveService.Coins);
    }
}