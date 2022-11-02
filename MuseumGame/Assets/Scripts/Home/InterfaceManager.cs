using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    //Set the UI for see the collection
    public VaseManager vaseManager;
    public GameObject[] vaseSlot;

    //Navigate in all the page
    public int page;
    public Text pageText;
    private void Start()
    {
        DiplayVase();
    }

    private void Update()
    {
        UpdatePage();
    }

    private void UpdatePage()
    {
        pageText.text = (page + 1) + "/" + (Mathf.Ceil(vaseSlot.Length / 4) + 1).ToString();
    }

    private void DiplayVase() {
        for (int i = 0; i < vaseManager.vases.Count; i++)
        {
            //Assign the information to the UI
            if (i > page * 2 && i < (page + 1) * 4)
            {
                vaseSlot[i].gameObject.SetActive(true);
                vaseSlot[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = vaseManager.vases[i].vaseName;
                vaseSlot[i].transform.GetChild(0).GetComponent<Image>().sprite = vaseManager.vases[i].founded;
                if (vaseManager.vases[i].isFounded)
                {
                    vaseSlot[i].transform.GetChild(2).GetComponent<Image>().enabled = false;
                }
            }
            else
            {
                vaseSlot[i].gameObject.SetActive(false);
            }
        }
    }

    public void GoNextPage()
    {
        if(page >= Mathf.Floor((vaseManager.vases.Count -1) / 4)) 
        {
            page = 0;
        }
        else
        {
            page++;
        }

        Debug.Log(page);
        DiplayVase();
    }

    public void GoPreviusPage()
    {
        if (page <= 0)
        {
            page = Mathf.FloorToInt((vaseManager.vases.Count - 1) / 4);
        }
        else
        {
            page--;
        }
        Debug.Log(page);
        DiplayVase();
    }
}
