using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class InterfaceManager : MonoBehaviour
{
    //Set the UI for see the collection
    public VaseManager vaseManager;
    public GameObject[] vaseSlot;

    //Navigate in all the page
    public int page;
    public Text pageText;
    public GameObject playMenuPanel;
    public GameObject viewMenuPanel;
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
        pageText.text = (page + 1) + "/" + Mathf.Ceil(vaseSlot.Length / 2).ToString();
    }

    private void DiplayVase() {
        for (int i = 0; i < vaseManager.vases.Count; i++)
        {
            //Assign the information to the UI
            if (i >= page * 2 && i < (page + 1) * 2)
            {
                vaseSlot[i].gameObject.SetActive(true);
                vaseSlot[i].transform.GetChild(0).GetComponent<Image>().sprite = vaseManager.vases[i].founded;
                if (vaseManager.vases[i].isFounded)
                {
                    vaseSlot[i].transform.GetChild(2).GetComponent<Image>().enabled = false;
                    vaseSlot[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = vaseManager.vases[i].vaseName;
                    vaseSlot[i].transform.GetChild(3).GetComponent<Button>().onClick.AddListener(OpenViewMenu);
                }
                else
                {
                    vaseSlot[i].transform.GetChild(2).GetComponent<Image>().enabled = true;
                    vaseSlot[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "????";
                    vaseSlot[i].transform.GetChild(3).GetComponent<Button>().onClick.AddListener(OpenPlayMenu);
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
        if(page >= Mathf.Floor((vaseManager.vases.Count -1) / 2)) 
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
            page = Mathf.FloorToInt((vaseManager.vases.Count - 1) / 2);
        }
        else
        {
            page--;
        }
        Debug.Log(page);
        DiplayVase();
    }

    //Manage the menu for play a game
    private void OpenPlayMenu()
    {
        playMenuPanel.SetActive(true);
    }

    public void ClosePlayMenu()
    {
        playMenuPanel.SetActive(false);
    }
    
    private void OpenViewMenu()
    {
        viewMenuPanel.SetActive(true);
    }

    public void CloseViewMenu()
    {
        viewMenuPanel.SetActive(false);
    }

    public void ViewVases()
    {
        SceneManager.LoadScene("3DVase");
    }
    public void PlayNewGame()
    {
        int randomNum = 0;

        randomNum = Random.Range(1, 3);
        switch (randomNum)
        {
            case 1:
                SceneManager.LoadScene("PuzzleGame");
                 break;
            case 2:
                SceneManager.LoadScene("TapTapGame");
                break;
            case 3:
                Debug.Log("Third minigame");
                break;
        }
    }
}
