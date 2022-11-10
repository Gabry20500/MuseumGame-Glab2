using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VaseManager : MonoBehaviour
{
    public static VaseManager instance { get; private set; }
    public List<Vase> vases = new List<Vase>();
    public Sprite[] puzzleSprite;
    public int idVase { get; private set; }
    public Sprite activeSprite { get; private set; }
    public bool remaning = true;
    public bool qualcosa = false;

    private void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetVase(int id)
    {
        idVase = id;
        SetSprite();
    }

    private void SetSprite()
    {

        switch (idVase)
        {
            case 1:
                activeSprite = puzzleSprite[0];
                break;
            case 2:
                activeSprite = puzzleSprite[1];
                break;
            case 3:
                activeSprite = puzzleSprite[2];
                break;
            case 4:
                activeSprite = puzzleSprite[3];
                break;
            case 8:
                activeSprite = puzzleSprite[4];
                break;
            case 9:
                activeSprite = puzzleSprite[5];
                break;
            case 10:
                activeSprite = puzzleSprite[6];
                break;
        }
        
    }

}
