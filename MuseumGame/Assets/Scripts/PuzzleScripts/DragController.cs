using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class DragController : MonoBehaviour
{

    private bool _IsDragActive = false;

    private Vector2 _screenPosition;
    private Vector3 _woldPosition;

    private Draggable _lastDraggable;

    private void Awake()
    {
        DragController[] controller = FindObjectsOfType<DragController>();
        if (controller.Length > 1)
        {
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        if (_IsDragActive)
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                Drop();
                return;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }else 
        if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _woldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_IsDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_woldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDraggable = draggable;
                    InitDrag();
                }
            }
        }

        
        Debug.Log(_IsDragActive);
    } 
   
    void InitDrag() 
    {
        _IsDragActive = true;
    }
     
     void Drag() 
     {
         _lastDraggable.transform.position = new Vector2(_woldPosition.x, _woldPosition.y);
     }
 
     void Drop()
     {
         _IsDragActive = false;
     }
}
            // if(hit.transform.CompareTag("Puzzle"))
            // {
            //     selectedPieces = hit.transform.gameObject;
            // }
            
            // if (Input.GetMouseButtonUp(0))
                        // {
                        //     selectedPieces = null;
                        // }
                        // if (selectedPieces != null)
                        // {
                        //     Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        //     selectedPieces.transform.position = new Vector3(MousePosition.x, MousePosition.y, 0);
                        // }