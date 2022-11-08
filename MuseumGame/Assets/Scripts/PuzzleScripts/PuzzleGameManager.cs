using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleGameManager : MonoBehaviour
{
    public PieceManager[] pieces;
    public GameObject pauseMenu;
    private int piecesNum;
    public int rightPosPiecesNum = 0;
    private bool isPossibleAddValue;
    private bool addValue;
    
    // Start is called before the first frame update
    void Start()
    {
        piecesNum = pieces.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(piecesNum);
        Debug.Log(rightPosPiecesNum);
        for (int i = 0; i < piecesNum; i++)
        {
            if (pieces[i].inRhightPosition && !pieces[i].addedValue)
            {
                    rightPosPiecesNum++;
                    pieces[i].addedValue = true;
            }
        }

        if (rightPosPiecesNum == piecesNum)
        {
            OpenPauseMenu();
        }
    }

    private void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
        
        VaseManager.instance.vases[VaseManager.instance.idVase - 1].isFounded = true;

    }
}
