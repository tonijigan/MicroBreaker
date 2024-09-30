using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    private const int MinHealth = 0;

    [SerializeField] private float _speedRepulsion;
    [SerializeField] private int _health;

    public event Action Died;

    private WaitForSeconds _waitForSeconds;
    private float _delay = 0.5f;

    public float GetSpeed()
    {
        return _speedRepulsion;
    }

    public void TakeDamage(int damage)
    {
        if (_health <= MinHealth)
        {
            StartCoroutine(Die());
            Died?.Invoke();
        }

        _health -= damage;
    }

    private IEnumerator Die()
    {
        _waitForSeconds = new(_delay);
        yield return _waitForSeconds;
        gameObject.SetActive(false);
        StopCoroutine(Die());
    }
}