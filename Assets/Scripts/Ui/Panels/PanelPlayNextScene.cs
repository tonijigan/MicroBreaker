namespace UI
{
    public class PanelPlayNextScene : Panel
    {
        public override async void Move(bool isActive)
        {
            base.Move(isActive);
            await MovePanel(isActive);
        }
    }
}