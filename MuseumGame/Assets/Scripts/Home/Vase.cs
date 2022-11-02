using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vase
{
    public string vaseName;
    [TextArea(1,3)]
    public string idCode;
    public bool isFounded;
    
    //sprite 
    public Sprite unknown;
    public Sprite founded;
}
