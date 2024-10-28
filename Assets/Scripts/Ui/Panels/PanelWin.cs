using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelWin : Panel
{
    [SerializeField] private Button _buttonTryAgain;
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _bluePowerUps;
    [SerializeField] private TMP_Text _bricksSmashed;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _credits;

    private void OnEnable()
    {
        _buttonTryAgain.onClick.AddListener(() => { LoadScene(ScenesName.Game.ToString()); });
        _buttonContinue.onClick.AddListener(() => { LoadScene(ScenesName.ChooseLevel.ToString()); });
    }

    private void OnDisable()
    {
        _buttonTryAgain.onClick.RemoveListener(() => { LoadScene(ScenesName.Game.ToString()); });
        _buttonContinue.onClick.RemoveListener(() => { LoadScene(ScenesName.ChooseLevel.ToString()); });
    }

    public void Fill(string time, string bluePowerUps, string bricksSmashed, string score, string credits)
    {
        _time.text = time;
        _bluePowerUps.text = bluePowerUps;
        _bricksSmashed.text = bricksSmashed;
        _score.text = score;
        _credits.text = credits;
    }

    public override async void Move(bool isActive)
    {
        base.Move(isActive);
        await MovePanel(isActive);
    }

    private void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
}