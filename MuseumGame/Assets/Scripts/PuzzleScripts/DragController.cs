using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public class DragController : MonoBehaviour
{
    public GameObject selectedPiace;
    private int c = 0, OIL = 1;
    private Touch _touch;
    
    private void Update()
    {

        if (Input.touchCount > 0) {
            
            _touch = Input.GetTouch(0);
            
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
                if (Input.touchCount == 0)
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
}