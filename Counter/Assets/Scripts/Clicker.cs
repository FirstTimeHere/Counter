using System.Collections;
using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private TextMeshProUGUI _textNumber;

    private Coroutine _coroutine;

    private int _number;

    private void Start()
    {
        _textNumber.text = _number.ToString();
        Restart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Stop();
            Restart();
        }
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(RunCountDown(_delay));
    }

    private IEnumerator RunCountDown(float delay)
    {
        var wait = new WaitForSecondsRealtime(delay);

        while (true)
        {
            _number++;
            DislpayCountDown(_number, _textNumber);
            yield return wait;
        }
    }

    private void DislpayCountDown(float number, TextMeshProUGUI text)
    {
        text.text = number.ToString();
    }
}
