using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class PanelLoss : Panel
{
    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
    }
}