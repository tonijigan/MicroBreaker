namespace UI
{
    public class PanelPlayNextScene : Panel
    {
        public override async void OnMove(bool isActive)
        {
            base.OnMove(isActive);
            await MovePanel(isActive);
        }
    }
}