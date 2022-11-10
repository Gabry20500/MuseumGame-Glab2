using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTapTapManager : MonoBehaviour
{
    
    [SerializeField] TMP_Text tapText;
    [SerializeField] TMP_Text tapRequiredText;
    [SerializeField] private int tapRequired;
    [SerializeField] private InputManagerTapTap inputManager;
    [SerializeField] private TimeManager timeSlider;
    [SerializeField] private GameObject square;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject WinMenu;
    [SerializeField] private GameObject LooseMenu;
    [SerializeField] private GameObject Light;
    public TimeManager time;
    public Sprite newSprite;
    private int tapMaded = 0;

    private SpriteRenderer squareRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        tapText.text = "0";
        tapRequiredText.text = tapRequired.ToString();
        squareRenderer = square.GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if (time.isTimeEnded)
        {
            EndGame();
        }
    }

    public void IncrementTap()
    {
        tapMaded++;
        tapText.text = tapMaded.ToString();
        if (tapMaded >= tapRequired)
        {
            LevelWin();
        }
    }
    public int GetTapMade()
    {
        return tapMaded;
    }
    public int GetTapReqired()
    {
        return tapRequired;
    }

    private void LevelWin()
    {
        
        inputManager.OnDisable();
        timeSlider.StopSlider();
        squareRenderer.sprite = newSprite;
        Light.SetActive(true);
        Light.GetComponent<Animation>().Play("LightAnimation");

        StartCoroutine(PauseMenu());
    }

    public void EndGame()
    {
        if (tapMaded < tapRequired)
        {
            LevelLoose();
        }
    }

    private void LevelLoose() 
    {
        MenuPanel.SetActive(true);
        WinMenu.SetActive(false);
        LooseMenu.SetActive(true);
    }

    public void GoToCollection()
    {
        SceneManager.LoadScene("Home");
    }

    private IEnumerator PauseMenu()
    {
        yield return new WaitForSeconds(1.5f);
        
        MenuPanel.SetActive(true);
        WinMenu.SetActive(true);
        LooseMenu.SetActive(false);
    }
}
