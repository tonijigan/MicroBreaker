using Boosters;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BoosterShield : AbstractBooster, ITrigger, ISound
{
    [SerializeField] private Transform _shieldObject;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private BorderCollisionWithLoss _triggerLoss;

    private Collider _collider;

    private void Start() => _collider = GetComponent<Collider>();

    public AudioClip GetClip()
    {
        return _audioClip;
    }

    public float GetSpeed()
    {
        return 2000;
    }

    public void Play(Vector3 point)
    {
        _particleSystem.transform.position = point;
        _particleSystem.Play();
    }

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        _collider.enabled = false;
        _shieldObject.gameObject.SetActive(false);
        _triggerLoss.gameObject.SetActive(true);
        boosterEffect.SetActionActive();
    }

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _collider.enabled = true;
        _shieldObject.gameObject.SetActive(true);
        _triggerLoss.gameObject.SetActive(false);
        boosterEffect.SetActionActive();
    }
}