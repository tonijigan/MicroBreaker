using Interfaces;
using UnityEngine;


public class BallEffect : MonoBehaviour, IEffect
{
    [SerializeField] private Transform _transformEffect;

    public void Play(Vector3 point) { }

    public void RotateTarget(Vector3 direction)
    {
        _transformEffect.LookAt(-direction);
    }
}