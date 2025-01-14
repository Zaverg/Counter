using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _wait;
    [SerializeField] private float _count;
    private int _buttonNumber = 0;

    private Coroutine _counterCoroutine;
    private WaitForSeconds _waitForSeconds;

    public event Action<float> Changed;

    public float Count => _count;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_wait);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_buttonNumber))
        {
            HandleWorkCounter();
        }
    }

    private void HandleWorkCounter()
    {
        if (_counterCoroutine != null)
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;

            return;
        }

        _counterCoroutine = StartCoroutine(Counting());
    }

    private IEnumerator Counting()
    {
        while (true)
        {
            yield return _waitForSeconds;
            _count++;
            Changed?.Invoke(_count);
        }
    }
}
