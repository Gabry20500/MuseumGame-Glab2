using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    //Set the UI for see the collection
    public GameObject[] vaseSlot;

    private string GameId;
    
    //Navigate in all the page
    public int pos;
    public int page;
    public Text pageText;
    public GameObject playMenuPanel;
    public GameObject viewMenuPanel;
    public GameObject playButton;
    public GameObject viewButton;
    
    private void Start()
    {
        DiplayVase();

        pos = EndGame(true);
        
        Debug.Log(VaseManager.instance.remaning); 
        if (pos == 10 && VaseManager.instance.remaning)
        {
            SceneManager.LoadScene("EndLevel");
            VaseManager.instance.remaning = false;
        }
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
        for (int i = 0; i < VaseManager.instance.vases.Count; i++)
        {
            //Assign the information to the UI
            if (i >= page * 2 && i < (page + 1) * 2)
            {
                vaseSlot[i].gameObject.SetActive(true);
                vaseSlot[i].transform.GetChild(0).GetComponent<Image>().sprite = VaseManager.instance.vases[i].founded;
                VaseManager.instance.SetVase(VaseManager.instance.vases[i].idVase);
                if (VaseManager.instance.vases[i].isFounded)
                {
                    vaseSlot[i].transform.GetChild(2).GetComponent<Image>().enabled = false;
                    vaseSlot[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = VaseManager.instance.vases[i].vaseName;
                    vaseSlot[i].transform.GetChild(3).gameObject.SetActive(false);
                    vaseSlot[i].transform.GetChild(4).gameObject.SetActive(true);
                }
                else
                {
                    vaseSlot[i].transform.GetChild(2).GetComponent<Image>().enabled = true;
                    vaseSlot[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text = "????";
                    vaseSlot[i].transform.GetChild(3).gameObject.SetActive(true);
                    vaseSlot[i].transform.GetChild(4).gameObject.SetActive(false);
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
        if(page >= Mathf.Floor((VaseManager.instance.vases.Count -1) / 2)) 
        {
            page = 0;
        }
        else
        {
            page++;
        }

        DiplayVase();
    }

    public void GoPreviusPage()
    {
        if (page <= 0)
        {
            page = Mathf.FloorToInt((VaseManager.instance.vases.Count - 1) / 2);
        }
        else
        {
            page--;
        }
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
    
    public void OpenViewMenu(int code)
    {
        
        switch (code)
        {
            case 1:
                VaseManager.instance.SetVase(1);
                break;
            case 2:
                VaseManager.instance.SetVase(2);
                break;
            case 3:
                VaseManager.instance.SetVase(3);
                break;
            case 4:
                VaseManager.instance.SetVase(4);
                break;
            case 5:
                VaseManager.instance.SetVase(5);
                break;
            case 6:
                VaseManager.instance.SetVase(6);
                break;
            case 7:
                VaseManager.instance.SetVase(7);
                break;
        }
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
        switch (GameId)
        {
            case "PZ":
                SceneManager.LoadScene("PuzzleGame");
                 break;
            case "TAP":
                SceneManager.LoadScene("TapTapGame");
                break;
            case "EXG":
                SceneManager.LoadScene("EscavatorGame");
                break;
        }
    }

    public void PlayPuzzleGame (int code)
    {
        switch (code)
        {
            case 1:
                GameId = "PZ";
                VaseManager.instance.SetVase(1);
                OpenPlayMenu();
                break;
            case 2:
                GameId = "PZ";
                VaseManager.instance.SetVase(2);
                OpenPlayMenu();
                break;
            case 3:
                GameId = "PZ";
                VaseManager.instance.SetVase(3);
                OpenPlayMenu();
                break;
            case 4:
                GameId = "PZ";
                VaseManager.instance.SetVase(4);
                OpenPlayMenu();
                break;
        }
    }
    
    public void PlayExcavateGame (int code)
    {
        switch (code)
        {
            case 5:
                GameId = "EXG";
                VaseManager.instance.SetVase(5);
                OpenPlayMenu();
                break;
            case 6:
                GameId = "EXG";
                VaseManager.instance.SetVase(6);
                OpenPlayMenu();
                break;
            case 7:
                GameId = "EXG";
                VaseManager.instance.SetVase(7);
                OpenPlayMenu();
                break;
        }
    }
    
    public void PlayTapGame (int code)
    {
        switch (code)
        {
            case 8:
                GameId = "TAP";
                VaseManager.instance.SetVase(8);
                OpenPlayMenu();
                break;
            case 9:
                GameId = "TAP";
                VaseManager.instance.SetVase(9);
                OpenPlayMenu();
                break;
            case 10:
                GameId = "TAP";
                VaseManager.instance.SetVase(10);
                OpenPlayMenu();
                break;
        }
    }

    private int EndGame( bool flag)
    {
        int value = 0;

        for (int i = 0; i < VaseManager.instance.vases.Count; i++)
        {
            if (VaseManager.instance.vases[i].isFounded == flag)
            {
                value++;
            }
        }

        return value;
    }

}
