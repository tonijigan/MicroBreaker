using BallObject;
using Boosters;
using Cinemachine;
using PlayerObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private const int Priority = 2;
    private const int DurationWin = 3;
    private const int DurationLoss = 1;

    [SerializeField] private Counter _counter;
    [SerializeField] private TriggerLoss _triggerLoss;
    [SerializeField] private PanelWin _panelWin;
    [SerializeField] private PanelLoss _panelLoss;
    [SerializeField] private CinemachineVirtualCamera _virtualEndCamera;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private BallMovement _ballMovement;
    [SerializeField] private SaveService _saveService;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PanelFade _panelFade;
    [SerializeField] private BoostersContainer _boostersContainer;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(DurationWin);
    }

    private void OnEnable()
    {
        _counter.Winned += OpenPanelWin;
        _triggerLoss.Lost += OpenPanelLoss;
        _panelWin.Clicked += LoadScene;
        _panelLoss.Clicked += LoadScene;
    }

    private void OnDisable()
    {
        _counter.Winned -= OpenPanelWin;
        _triggerLoss.Lost -= OpenPanelLoss;
        _panelWin.Clicked -= LoadScene;
        _panelLoss.Clicked -= LoadScene;
    }

    private void OpenPanelWin(string time)
    {
        _virtualEndCamera.Priority = Priority;
        _boostersContainer.Reset();
        _waitForSeconds = new WaitForSeconds(DurationWin);
        PlayOpen(_panelWin, _waitForSeconds, () =>
        {
            _panelWin.Fill(time, 0.ToString(), _counter.CountLiveBoxs.ToString(), 0.ToString(), _wallet.Coin.ToString());
            SaveGameProgress();
        });
    }

    private void OpenPanelLoss()
    {
        _boostersContainer.Reset();
        _waitForSeconds = new WaitForSeconds(DurationLoss);
        PlayOpen(_panelLoss, _waitForSeconds, () =>
        {
            _panelLoss.Fill(_counter.CountLiveBoxs.ToString(), _wallet.Coin.ToString());
        });
    }

    private void PlayOpen(Panel panel, WaitForSeconds waitForSeconds, Action action = null)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MovePatel(panel, waitForSeconds, action));
    }

    private IEnumerator MovePatel(Panel panel, WaitForSeconds waitForSeconds, Action action = null)
    {
        _playerInput.SetControl();
        _ballMovement.gameObject.SetActive(false);
        yield return waitForSeconds;
        panel.Move(true);
        action?.Invoke();
    }

    private void SaveGameProgress()
    {
        _saveService.SaveCoins(_saveService.Coins + _wallet.Coin);
        List<string> list = _saveService.LocationNames.ToList();
        list.Add(_counter.CurrentLocation.LocationName);
        _saveService.SaveArrayLocationNames(list.ToArray());
    }

    private void LoadScene(string sceneName)
    {
        _panelFade.SetActive(false, () => { SceneManager.LoadScene(sceneName); });
    }
}