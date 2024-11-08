public class RootStartScene : Root
{
    protected override void OnInit()
    {
        Wallet.Init(SaveService.Coins);
    }
}