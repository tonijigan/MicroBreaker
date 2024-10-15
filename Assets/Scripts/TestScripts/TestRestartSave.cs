using UnityEngine;

public class TestRestartSave : AbstractButton
{
    [SerializeField] private SaveService _saveService;

    protected override void OnClick()
    {
        _saveService.SaveCurrentBall("");
        _saveService.SaveCurrentPlatform("");
        _saveService.SaveArrayBalls(new string[0]);
        _saveService.SaveArrayPlatforms(new string[0]);
    }
}