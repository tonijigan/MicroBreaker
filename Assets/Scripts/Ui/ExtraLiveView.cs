using BallObject;
using TMPro;
using UnityEngine;

public class ExtraLiveView : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _textCount;

    private void OnEnable() => _ball.ExtraLiveChanged += OnSetValue;

    private void OnDisable() => _ball.ExtraLiveChanged -= OnSetValue;

    private void OnSetValue(int extraLive) => _textCount.text = extraLive.ToString();
}