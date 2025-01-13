using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Changed += ChangeTextCounter;
    }

    private void OnDisable()
    {
        _counter.Changed -= ChangeTextCounter;
    }

    private void ChangeTextCounter(float newCount)
    {
        _text.text = newCount.ToString();
    }
}
