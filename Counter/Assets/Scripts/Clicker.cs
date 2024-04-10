using System.Collections;
using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private TextMeshProUGUI _textNumber;

    private int _number;
    private static int s_mouseButton=0;

    private void Start()
    {
        _textNumber.text = _number.ToString();
        StartCoroutine(RunCountDown());
    }

    private void Update()
    {
        if (Input.GetMouseButton(s_mouseButton))
        {
            StopCoroutine(CountDown());
            DislpayCountDown(_number++);
        }
    }

    private IEnumerator RunCountDown()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            _number++;
            DislpayCountDown(_number);
            yield return wait;
        }
    }

    private void DislpayCountDown(float number)
    {
        _textNumber.text = number.ToString("");
    }
}
