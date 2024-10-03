using BallObject;
using PlatformObject;
using System.Collections.Generic;
using UnityEngine;

public class TemplateChangeControl : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private Ball _ball;
    [SerializeField] private List<BallTemplate> _ballTemplates;
    [SerializeField] private List<PlatformTemplate> _platformTemplates;

    private BallTemplate[] _balls;

    private void Awake()
    {
        _balls = new BallTemplate[_ballTemplates.Count];

        for (int i = 0; i < _ballTemplates.Count; i++)
        {
            _balls[i] = Instantiate(_ballTemplates[i]);
            _balls[i].gameObject.SetActive(false);
        }

        Debug.Log(_balls.Length);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            _ball.Change(_balls[0]);
        }
    }
}
