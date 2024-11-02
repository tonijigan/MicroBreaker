using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    private const float WaitSeconds = 0.5f;

    [SerializeField] private LaserBullet _laserBullet;
    [SerializeField] private int _countBullets;
    [SerializeField] private Transform _firstShootPoints;
    [SerializeField] private Transform _secondShootPoints;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;
    private Transform _currentPointTransform;

    private readonly List<LaserBullet> _laserBullets = new();

    private void Awake() => Create();

    public void Shooting()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(EnableBullets());
    }

    private void Create()
    {
        _waitForSeconds = new(WaitSeconds);
        _currentPointTransform = _secondShootPoints;

        for (int i = 0; i < _countBullets; i++)
        {
            _laserBullets.Add(Instantiate(_laserBullet, GetPosition()));
            _laserBullets[i].gameObject.SetActive(false);
        }
    }

    private IEnumerator EnableBullets()
    {
        foreach (var laserBullet in _laserBullets)
        {
            laserBullet.gameObject.SetActive(true);
            laserBullet.transform.parent = null;
            yield return _waitForSeconds;
        }

        StopCoroutine(_coroutine);
    }

    private Transform GetPosition()
    {
        if (_currentPointTransform == _secondShootPoints)
            return _currentPointTransform = _firstShootPoints;

        if (_currentPointTransform == _firstShootPoints)
            return _currentPointTransform = _secondShootPoints;

        return _currentPointTransform;
    }
}