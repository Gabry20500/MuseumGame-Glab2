using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PieceManager : MonoBehaviour
{
    Vector3 _rightPosition;
    public bool inRhightPosition;
    public bool selected;
    private Renderer _pieceRenderer;
    private int _rightPositionPiece = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _pieceRenderer = new Renderer();
        _rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(2.4f,7.5f),Random.Range(9.7f,5.5f));
        Debug.Log(_rightPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _rightPosition) < 0.5f)
        {
            if (!selected)
            {
                transform.position = _rightPosition;
                inRhightPosition = true;
                _pieceRenderer.sortingOrder = 0; 

            }
        }
    }

    private void IncrementRightPositionPiece()
    {
        _rightPositionPiece++;

        if (_rightPositionPiece >= 36)
        {
            
        }
    }
}
