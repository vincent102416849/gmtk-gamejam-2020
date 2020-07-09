using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GMTKCounter : MonoBehaviour
{
    public TextMeshProUGUI countDownTMP;
    public string endTimeStr;
    
    void Update()
    {
        var currentTime = DateTime.Now;
        var endTime = DateTime.Parse(endTimeStr);
        var timeSpan = endTime - currentTime;
        countDownTMP.SetText($"{timeSpan.Days} days {timeSpan.Hours} hours {timeSpan.Minutes} minutes {timeSpan.Seconds} seconds");
    }
}
