using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] TMP_Text tapText;
    [SerializeField] TMP_Text tapRequiredText;
    [SerializeField] private int tapRequired;
    [SerializeField] private InputManagerTapTap inputManager;
    [SerializeField] private TimeManager timeSlider;
    [SerializeField] private GameObject square;
    public Sprite newSprite;
    private int tapMade = 0;

    private SpriteRenderer squareRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        tapText.text = "0";
        tapRequiredText.text = tapRequired.ToString();
        squareRenderer = square.GetComponent<SpriteRenderer>();
        
    }
    
    public void IncrementTap()
    {
        tapMade++;
        tapText.text = tapMade.ToString();
        if (tapMade >= tapRequired)
        {
            LevelWin();
        }
    }
    public int GetTapMade()
    {
        return tapMade;
    }
    public int GetTapReqired()
    {
        return tapRequired;
    }

    private void LevelWin()
    {
        inputManager.OnDisable();
        tapRequiredText.text = "You Win";
        timeSlider.StopSlider();
        squareRenderer.sprite = newSprite;
    }
}
