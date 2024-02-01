using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    float second = 0;
    float minute = 0;

    void Update()
    {
        second += Time.deltaTime;

        if (second >= 59)
        {
            minute++;
            second = 0;
        }

        GetComponent<TextMeshProUGUI>().text = string.Format("TIME {0:00} : {1:00}", minute, second);
    }
}
