using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timer_text;
    private float timer_float;
    private int timer_int_sec;
    private int timer_int_min;
    private string timer_int_sec_text;
    private string timer_int_min_text;
    void Start()
    {
        timer_float = 0f;
        timer_int_sec = 0;
        timer_int_min = 0;
    }

    void Update()
    {
        timer_float += Time.deltaTime;
        if (Mathf.Floor(timer_float) > timer_int_sec)
        {
            timer_int_sec++;
        }
        if (timer_int_sec == 60)
        {
            timer_int_sec = 0;
            timer_int_min++;
            timer_float = 0f;
        }
        if (timer_int_sec < 10)
        {
            timer_int_sec_text = $"0{timer_int_sec}";
        } else
        {
            timer_int_sec_text = timer_int_sec.ToString();
        }
        if (timer_int_min < 10)
        {
            timer_int_min_text = $"0{timer_int_min}";
        }
        else
        {
            timer_int_min_text = timer_int_min.ToString();
        }
        timer_text.text = $"Timer : {timer_int_min_text}:{timer_int_sec_text}";
    }
}
