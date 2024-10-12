using Enums;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayGame : AbstractButton
{
    [SerializeField] private Save _save;
    [SerializeField] private ScenesName _scenesName;
    [SerializeField] private TMP_Text _text;

    public event Action Clicked;

    private LocationObject _locationObject;

    protected override void OnClick()
    {
        _save.SetName(_locationObject.Name.ToString());
        SceneManager.LoadScene(_scenesName.ToString());
    }

    public void Init(LocationObject locationObject)
    {
        _locationObject = locationObject;

        this.enabled = true;
        _text.text = "���� ������";

        if (_locationObject.IsActive == false)
        {
            _text.text = "��� �������";
            this.enabled = false;
        }

        Clicked?.Invoke();
    }
}