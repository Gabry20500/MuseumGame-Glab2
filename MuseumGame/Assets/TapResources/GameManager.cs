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
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TimeManager timeSlider;
    [SerializeField] private GameObject panel;
    public Material boxMaterial;
    private int tapMade = 0;

    private Renderer panelRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        tapText.text = "0";
        tapRequiredText.text = tapRequired.ToString();
        panelRenderer = panel.GetComponent<Renderer>();
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
        panelRenderer.material = boxMaterial;
    }
}
