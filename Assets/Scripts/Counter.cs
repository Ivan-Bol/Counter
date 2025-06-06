using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _delay;
    [SerializeField] private TextMeshProUGUI _text;
    private int _counter = 0;
    private Coroutine _coroutine;
    
    private void Update()
    {
        CounterWork();
    }

    private void CounterWork()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Произошло нажатие");

            if (_coroutine != null)
            {
                Debug.Log("Счетчик остановлен");
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
            else
            {
                Debug.Log("Счетчик работает");
                _coroutine = StartCoroutine(Countdown(_delay));
            }
        }
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);
        bool isWork = true;

        while (isWork)
        {
            yield return wait;

            DisplayCountdown();
            _counter += 1;
        }
    }

    private void DisplayCountdown()
    {
        _text.text = _counter.ToString();
    }
}
