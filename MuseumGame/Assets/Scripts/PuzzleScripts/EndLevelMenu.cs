using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EndLevelMenu : MonoBehaviour
{
    public bool gameIsEnded = false;

    public GameObject endGameMenuUi;

    private void Start()
    {
        endGameMenuUi.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
