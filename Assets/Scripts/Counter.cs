using System;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _wait;
    [SerializeField] private float _count;
    private int _buttonNumber = 0;

    private Coroutine _counterCoroutine;

    public event Action<float> Changed;

    public float Count => _count;

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
            return;
        }

        _counterCoroutine = StartCoroutine(Counting());
    }

    private IEnumerator<WaitForSeconds> Counting()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_wait);
        
        while (true)
        {
            yield return waitForSeconds;
            _count += 1;
            Changed?.Invoke(_count);
        }
    }
}
