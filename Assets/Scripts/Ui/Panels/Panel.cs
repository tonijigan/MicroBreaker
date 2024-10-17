using DG.Tweening;
using System;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public virtual void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}