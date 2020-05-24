using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 10;
    public float startTime = 60;

    public Text CountDownText;
    void Start()
    {
        currentTime = startTime;
    }
    
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
            CountDownText.text = currentTime.ToString("0");
        }

        if (currentTime >= 10) { CountDownText.color = Color.black; }
        if (currentTime < 10) { CountDownText.color = Color.red; }

    }
}

