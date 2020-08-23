using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float timerStart = 60;
    public Text textBox;
    void Start()
    {
        textBox.text = timerStart.ToString();
    }

    void Update()
    {
        if (timerStart > 0)
        {
            timerStart -= Time.deltaTime;
            textBox.text = Math.Round(timerStart, 2).ToString();
            if (timerStart < 0.00f)
            {
                timerStart = 0.00f;
            }
        }
        else
            timerStart = 0.00f;
    }
}
