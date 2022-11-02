using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public VaseManager vaseManager;
    public GameObject[] vaseSlot;

    private void Start()
    {
        DiplayVase();
    }

    private void DiplayVase()
    {
        for (int i = 0; i < vaseManager.vases.Count; i++)
        {
            //Assign the information to the UI
            vaseSlot[i].transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshPro>().text = vaseManager.vases[i].vaseName;
        }
    }
}
