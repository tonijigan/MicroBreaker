using System;
using LocationLogic;
using UnityEngine;

namespace CounterLogic
{
    public class Counter : MonoBehaviour
    {
        private const int Seconds = 60;

        [SerializeField] private LocationCreate _locationCreate;

        public event Action<string> Winned;

        private float _time = 0;

        public Location CurrentLocation { get; private set; }

        public int CountLiveBoxs { get; private set; }

        private void OnEnable()
        {
            _locationCreate.Inited += OnInit;
            _locationCreate.Inited += OnInit =>
            {
                foreach (var box in CurrentLocation.BoxContainer.Boxes)
                    box.Died += SetDestroyBox;
            };
        }

        private void OnDisable()
        {
            _locationCreate.Inited -= OnInit;
            _locationCreate.Inited -= OnInit =>
            {
                foreach (var box in CurrentLocation.BoxContainer.Boxes)
                    box.Died -= SetDestroyBox;
            };
        }

        //
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
                Winned?.Invoke(GetResultTime());
        }

        public void UpdateTime() => _time += Time.deltaTime;

        private void OnInit(Location currentLocation) => CurrentLocation = currentLocation;

        private string GetResultTime()
        {
            return $"{(int)_time / Seconds}:{(int)_time}";
        }

        private void SetDestroyBox()
        {
            foreach (var box in CurrentLocation.BoxContainer.Boxes)
                box.Rigidbody.WakeUp();

            CountLiveBoxs++;

            if (CountLiveBoxs == CurrentLocation.BoxContainer.Boxes.Length)
                Winned?.Invoke(GetResultTime());
        }
    }
}