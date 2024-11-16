using Enums;
using UnityEngine;

namespace BoosterLogic
{
    public class BoosterHandler : MonoBehaviour
    {
        [SerializeField] private AbstractBooster[] _abstractBoostersWhitTimer;
        [SerializeField] private Transform _boosterViewContainer;
        [SerializeField] private BoosterView _boosterViewPrefab;

        private void OnEnable()
        {
            foreach (var abstractBoosterWithTimer in _abstractBoostersWhitTimer)
                abstractBoosterWithTimer.Played += OnAddBoosterView;
        }

        private void OnDisable()
        {
            foreach (var abstractBoosterWithTimer in _abstractBoostersWhitTimer)
                abstractBoosterWithTimer.Played -= OnAddBoosterView;
        }

        private void OnAddBoosterView(Sprite sprite, BoosterNames boosterNames)
        {
            BoosterView boosterView = Instantiate(_boosterViewPrefab, _boosterViewContainer);
            boosterView.Init(sprite, boosterNames);
        }
    }
}