using UnityEngine;

namespace UI
{
    public class PanelPlayNextScene : Panel
    {
        [SerializeField] private RectTransform _buttonPlayRectTransform;

        public override async void Move(bool isActive)
        {
            base.Move(isActive);
            await MovePanel(isActive);
        }
    }
}