using BallObject;
using Cinemachine;
using PlayerObject;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private const int Priority = 2;
    private const int DurationWin = 3;
    private const int DurationLoss = 1;

    [SerializeField] private Counter _counter;
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private PanelLoss _panelLoss;
    [SerializeField] private CinemachineVirtualCamera _virtualEndCamera;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private Button _testButtonLoss;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(DurationWin);
    }

    private void OnEnable()
    {
        _counter.Winned += OpenPanelWin;
        _testButtonLoss.onClick.AddListener(OpenPanelLoss);
    }

    private void OnDisable()
    {
        _counter.Winned -= OpenPanelWin;
        _testButtonLoss.onClick.RemoveListener(OpenPanelLoss);
    }

    private void OpenPanelWin(string time)
    {
        _virtualEndCamera.Priority = Priority;

        _waitForSeconds = new WaitForSeconds(DurationWin);
        PlayCoroutine(_panelWin, _waitForSeconds);
    }

    private void OpenPanelLoss()
    {
        _waitForSeconds = new WaitForSeconds(DurationLoss);
        PlayCoroutine(_panelLoss, _waitForSeconds);
    }

    private void PlayCoroutine(Panel panel, WaitForSeconds waitForSeconds)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MovePatel(panel, waitForSeconds));
    }

    private IEnumerator MovePatel(Panel panel, WaitForSeconds waitForSeconds)
    {
        _playerInput.SetControl();
        _ballMovement.gameObject.SetActive(false);
        yield return waitForSeconds;
        panel.Move(true);
    }
}