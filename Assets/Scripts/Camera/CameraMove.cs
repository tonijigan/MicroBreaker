using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private Vector3 _currentPosition;
    private Coroutine _coroutine;

    private void Update()
    {
        _currentPosition = new(Mathf.Clamp(_virtualCamera.Follow.position.x, -3f, 3f),
                                             _virtualCamera.transform.position.y,
                                             _virtualCamera.transform.position.z);
    }

    private void LateUpdate()
    {
        if (_virtualCamera.Follow.position.x > 5 || _virtualCamera.Follow.position.x < -5)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            var newPosition = _currentPosition;
            _coroutine = StartCoroutine(MoveX(newPosition));
        }
    }

    private IEnumerator MoveX(Vector3 position)
    {

        while (_virtualCamera.transform.position != position)
        {
            _virtualCamera.transform.position = Vector3.Lerp(_virtualCamera.transform.position, position, 0.8f * Time.deltaTime);
            yield return null;
        }
    }
}