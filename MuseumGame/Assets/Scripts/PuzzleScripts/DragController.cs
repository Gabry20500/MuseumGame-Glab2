using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class DragController : MonoBehaviour
{
    [FormerlySerializedAs("_selectedPiace")] public GameObject selectedPiace;
    private int c = 0, OIL = 1;
    private Touch _touch;
    private void Update()
    {
        DetectTouch();
        
        if (_touch.phase == TouchPhase.Began) {
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(_touch.position), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PieceManager>().inRhightPosition)
                {
                    selectedPiace = hit.transform.gameObject;
                    selectedPiace.GetComponent<PieceManager>().selected = true;
                }
            }
            c = 1;
            
            //Input.GetTouch(0).position
        }else 
        if (Input.GetMouseButtonDown(0)) {
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PieceManager>().inRhightPosition)
                {
                    selectedPiace = hit.transform.gameObject;
                    selectedPiace.GetComponent<PieceManager>().selected = true;
                    selectedPiace.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
            c = 2;
            
        }
        
        

        switch (c)
        {
            case 1: 
                if (_touch.phase == TouchPhase.Ended)
                {
                    if (selectedPiace != null)
                    {
                        selectedPiace.GetComponent<PieceManager>().selected = false;
                        selectedPiace = null;
                    }
                }
                
                if (selectedPiace != null)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(_touch.position);
                    selectedPiace.transform.position = new Vector3(touchPos.x, touchPos.y,0);
                }
                break;
            
            case 2:
                if (Input.GetMouseButtonUp(0))
                {
                    if (selectedPiace != null)
                    {
                        selectedPiace.GetComponent<PieceManager>().selected = false;
                        selectedPiace = null;
                    }
                }
                
                if (selectedPiace != null)
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    selectedPiace.transform.position = new Vector3(mousePos.x, mousePos.y,0);
                }
                break;
        }
        
    }

    private void DetectTouch()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
        }
    }
}