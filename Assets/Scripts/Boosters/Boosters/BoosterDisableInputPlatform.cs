using Boosters;
using PlatformObject;
using System.Collections;
using UnityEngine;

public class BoosterDisableInputPlatform : AbstractBooster
{
    private const int WaitSeconds = 2;

    [SerializeField] private InputPointMovement _inputPointMovement;

    private WaitForSeconds _wait;
    private Coroutine _coroutine;

    private void Start() => _wait = new WaitForSeconds(WaitSeconds);

    public override void OnStartAction(BoosterEffect boosterEffect)
    {
        _coroutine = StartCoroutine(EnableInputMovement());
        boosterEffect.SetActionActive();
    }

    public override void StopAction(BoosterEffect boosterEffect)
    {
        if (boosterEffect.IsActive == false) return;

        _inputPointMovement.gameObject.SetActive(true);
        boosterEffect.SetActionActive();
    }

    private IEnumerator EnableInputMovement()
    {
        _inputPointMovement.gameObject.SetActive(false);
        yield return _wait;
        _inputPointMovement.gameObject.SetActive(true);
        StopCoroutine(_coroutine);
    }
}