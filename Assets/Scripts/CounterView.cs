using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private float _lastNumber;

    private void Start()
    {
        _lastNumber = 0;
    }

    private void Update()
    {
        if (_lastNumber != _counter.Count)
        {
            _lastNumber = _counter.Count;
            _text.text = _lastNumber.ToString();
            Debug.Log(_lastNumber);
        }
    }
}
