using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    private Vector3 _rightPosition;
    public bool inRhightPosition;
    public bool selected;
    
    // Start is called before the first frame update
    void Start()
    {
        _rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(2.4f,7.5f),Random.Range(9.7f,5.5f));
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
            }
        }
    }
}
