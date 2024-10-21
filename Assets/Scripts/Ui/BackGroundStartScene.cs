using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class BackGroundStartScene : MonoBehaviour
{
    private Transform _transform;
    private Transform[] _transformsBox;
    private Coroutine _coroutine;

    private void Start()
    {
        Fill();
    }

    private void Fill()
    {
        _transform = transform;
        _transformsBox = new Transform[_transform.childCount];

        for (int i = 0; i < _transformsBox.Length; i++)
        {
            _transformsBox[i] = _transform.GetChild(i);
        }

        MoveCoroutine();
    }

    private void MoveCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float randomX;
        for (int i = 0; i < _transformsBox.Length; i++)
        {
            randomX = UnityEngine.Random.Range(0.1f, 1f);
            _transformsBox[i].DOLocalMoveX(randomX, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            yield return new WaitForSeconds(0.01f);
        }
    }
}