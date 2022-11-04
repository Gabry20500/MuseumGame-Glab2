using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class PieceManager : MonoBehaviour
{
    Vector3 _rightPosition;
    public bool inRhightPosition;
    public bool selected;
    private Renderer _pieceRenderer;
    public bool addedValue;
    private EndLevelMenu _endLevelMenu;

    // Start is called before the first frame update
    void Start()
    {
        _pieceRenderer = new Renderer();
        _rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(172f,1226f),Random.Range(1500f,500f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _rightPosition) < 8f)
        {
            if (!selected)
            {
                transform.position = _rightPosition;
                inRhightPosition = true;
            }
        }
    }
}
