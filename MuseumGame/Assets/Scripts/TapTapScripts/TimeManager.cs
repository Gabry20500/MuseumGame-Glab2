using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Timeline;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Slider timeSlider;
    public int maxTime;
    private bool isActive = true;
    private int time;
    public bool isTimeEnded = false;
    // Start is called before the first frame update
    private void Start()
    {
        timeSlider.value = 0;
        timeSlider.maxValue = maxTime;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isActive == true)
        {
            timeSlider.value += Time.deltaTime;
            time = (int)timeSlider.value;
            
            if(timeSlider.value >= maxTime)
            {
                StopSlider();
                isTimeEnded = true;
            }
        }
        
    }

    public void StopSlider()
    {
        isActive = false;
    }
}
