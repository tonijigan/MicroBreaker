using System;
using UnityEngine;

public class ButtonPanelInteraction : AbstractButton
{
    [SerializeField] private Panel _panelOpenPanel;
    [SerializeField] private Panel[] _panelClosePanel = null;
    [SerializeField] private bool _isStateOnOpenPanel = true;

    public event Action<bool> Clicked;

    protected override void OnClick()
    {
        if (_panelClosePanel != null)
            ClosePanels();
        if (_panelOpenPanel != null)
            _panelOpenPanel.gameObject.SetActive(_isStateOnOpenPanel);

        Clicked?.Invoke(_isStateOnOpenPanel);
    }

    private void ClosePanels()
    {
        foreach (var panel in _panelClosePanel)
        {
            panel.gameObject.SetActive(!_isStateOnOpenPanel);
        }
    }
}