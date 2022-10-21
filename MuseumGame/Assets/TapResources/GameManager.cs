using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int tapRequired;
    [SerializeField] TMP_Text tapText;
    [SerializeField] TMP_Text tapRequiredText;

    // Start is called before the first frame update
    void Start()
    {
        tapText.text = "0";
        tapRequiredText.text = tapRequired.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
