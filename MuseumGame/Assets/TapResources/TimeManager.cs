using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Slider timeSlider;
    public int maxTime;
    // Start is called before the first frame update
    void Start()
    {
        timeSlider.value = 0;
        timeSlider.maxValue = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeSlider.value += Time.deltaTime;
        if(timeSlider.value >= maxTime)
        {
            timeSlider.value = 0;
        }
    }
}
