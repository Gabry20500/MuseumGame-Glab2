using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    public PieceManager[] pieces;

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
        Debug.Log(rightPosPiecesNum);
        for (int i = 0; i < piecesNum; i++)
        {
            Debug.Log($"Pieces {i} is {pieces[i].addedValue} and is right? > {pieces[i].inRhightPosition}");
            if (pieces[i].inRhightPosition && !pieces[i].addedValue)
            {
                    rightPosPiecesNum++;
                    pieces[i].addedValue = true;
            }
        }
    }

    private void AddValue()
    {
        
    }
}
