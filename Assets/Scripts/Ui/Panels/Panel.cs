using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Panel : MonoBehaviour
{
    public event Action Moved;

    public virtual void Move(bool isAction)
    {
        Moved?.Invoke();
    }
}