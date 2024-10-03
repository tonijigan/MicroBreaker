using BallObject;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TemplateChangeControl : MonoBehaviour
{
    [SerializeField] private PlatformTrigger _platformTrigger;
    [SerializeField] private Ball _ball;
    [SerializeField] private List<BallTemplate> _ballTemplates;
    [SerializeField] private List<PlatformTemplate> _platformTemplates;

    private BallTemplate[] _balls;

    private BallTemplate _oldBallTemplate;

    private void Awake()
    {
        _balls = new BallTemplate[_ballTemplates.Count];

        for (int i = 0; i < _ballTemplates.Count; i++)
        {
            _balls[i] = Instantiate(_ballTemplates[i], transform);
            _balls[i].gameObject.SetActive(false);
        }

        Debug.Log(_balls.Length);
    }

    private void OnEnable()
    {
        _platformTrigger.BoosterSended += OnAcceptBooster;
    }

    private void OnDisable()
    {
        _platformTrigger.BoosterSended -= OnAcceptBooster;
    }

    private void OnAcceptBooster(Booster booster)
    {
        BallTemplate _currentBallTemplate = _balls.Where(template => template.ObjectsName == booster.Name).FirstOrDefault();

        if (_currentBallTemplate == _oldBallTemplate)
            return;

        Debug.Log(_currentBallTemplate.ObjectsName);
        _ball.Change(_currentBallTemplate);


        _oldBallTemplate = _currentBallTemplate;
    }
}
