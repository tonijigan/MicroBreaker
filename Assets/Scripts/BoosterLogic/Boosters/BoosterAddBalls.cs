using BallObject;
using Enums;
using Shop;
using UnityEngine;

namespace BoosterLogic.Boosters
{
    public class BoosterAddBalls : AbstractBooster
    {
        private const int Count = 3;
        private const float RandomValue = 1;
        private const int Speed = 1000;
        private const int MinValue = 0;

        [SerializeField] private Ball _ball;

        private Ball[] _balls;

        public override void StopAction(BoosterEffect boosterEffect)
        {
            if (boosterEffect.IsActive == false) return;

            boosterEffect.SetActionActive();
            _ball.BallEffect.SetParticleSystem(BoosterNames.Default);

            foreach (var ball in _balls)
                ball.gameObject.SetActive(false);
        }

        public override void OnStartAction(BoosterEffect boosterEffect)
        {
            boosterEffect.SetActionActive();
            _balls = new Ball[Count];
            _ball.transform.GetChild(MinValue).TryGetComponent(out ChangeTemplate changeTemplate);
            _ball.BallEffect.SetParticleSystem(BoosterName);
            string currentName = changeTemplate.CurrentTemplate.Name;

            for (int i = 0; i < _balls.Length; i++)
            {
                _balls[i] = Instantiate(_ball, Transform);
                _balls[i].transform.GetChild(MinValue).TryGetComponent(out ChangeTemplate changeTemplateClone);
                _balls[i].OnDisconnectParentObject();
                _balls[i].BallEffect.SetParticleSystem(BoosterName);
                _balls[i].Rigidbody.AddForce(new Vector3(Random.Range(-RandomValue, RandomValue), MinValue,
                                                         Random.Range(-RandomValue, RandomValue)) * Speed);
                changeTemplateClone.EnableCurrentTemplate(currentName, MinValue);
            }
        }
    }
}