using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LaserGunSound : MonoBehaviour
{
    [SerializeField] private LaserGun laserGun;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}