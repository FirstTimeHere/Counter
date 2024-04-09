using System.Collections;
using TMPro;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private TextMeshProUGUI _textNumber;

    private int _number;

    private void Start()
    {
        _textNumber.text = _number.ToString();
        StartCoroutine(RunCorutain());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StopCoroutine(RunCorutain());
            DislpayCountDown(_number++);
        }
    }

    private IEnumerator RunCorutain()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            _number++;
            DislpayCountDown(_number);
            yield return wait;
        }
    }

    private void DislpayCountDown(float elapsedTime)
    {
        _textNumber.text = elapsedTime.ToString("");
    }
}
