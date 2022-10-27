using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Timeline;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Slider timeSlider;
    [SerializeField] TMP_Text timeText;
    public int maxTime;
    private bool isActive = true;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        timeSlider.value = 0;
        timeSlider.maxValue = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            timeSlider.value += Time.deltaTime;
            time = (int)timeSlider.value;
            timeText.text = time.ToString();
            
            if(timeSlider.value >= maxTime)
            {
                timeSlider.value = 0;
            }
        }
        
    }

    public void StopSlider()
    {
        isActive = false;
    }
}
