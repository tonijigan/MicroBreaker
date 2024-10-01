using Interfaces;
using UnityEngine;

public abstract class AbstractEffect : MonoBehaviour, IEffect
{
    [SerializeField] private ParticleSystem _particleSystem;

    public void Play(Vector3 point)
    {
        _particleSystem.transform.position = point;
        _particleSystem.Play();
    }
}
