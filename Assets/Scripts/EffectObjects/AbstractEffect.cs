using Interfaces;
using UnityEngine;

public abstract class AbstractEffect : MonoBehaviour, IEffect
{
    protected ParticleSystem ParticleSystem;

    public void Play(Vector3 point)
    {
        ParticleSystem.transform.position = point;
        ParticleSystem.Play();
    }
}
