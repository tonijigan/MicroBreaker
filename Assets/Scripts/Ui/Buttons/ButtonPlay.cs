using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : AbstractButton
{
    [SerializeField] private ScenesName _scenesName;

    protected override void OnClick()
    {
        SceneManager.LoadScene(_scenesName.ToString());
    }
}