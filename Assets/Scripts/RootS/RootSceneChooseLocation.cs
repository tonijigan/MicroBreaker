namespace Roots
{
    public class RootSceneChooseLocation : Root
    {
        protected override void OnInit() => Wallet.Init(SaveService.Coins);
    }
}