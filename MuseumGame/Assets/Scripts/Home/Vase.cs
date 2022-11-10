using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Vase
{
    public string vaseName;
    [TextArea(1,3)]
    public string idGame;
    public int idVase;
    public bool isFounded;
    
    //sprite 
    public Sprite founded;
    
    //Button
    public Button playGame;
}
