using UnityEngine;

public class DragController : MonoBehaviour
{
    public GameObject _selectedPiace;
    private int c = 0;
    private void Update()
    {
        // if (Input.touchCount > 0) {
        //     
        //     RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
        //     if (hit.transform.CompareTag("Puzzle"))
        //     {
        //         if (!hit.transform.GetComponent<PieceManager>().inRhightPosition)
        //         {
        //             _selectedPiace = hit.transform.gameObject;
        //             _selectedPiace.GetComponent<PieceManager>().selected = true;
        //         }
        //        
        //     }
        //     c = 1;
        //     
        // }else 
        if (Input.GetMouseButtonDown(0)) {
            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PieceManager>().inRhightPosition)
                {
                    _selectedPiace = hit.transform.gameObject;
                    _selectedPiace.GetComponent<PieceManager>().selected = true;
                }
            }
            c = 2;
            
        }

        switch (c)
        {
            case 1: 
                if (Input.touchCount == 0)
                {
                    _selectedPiace.GetComponent<PieceManager>().selected = false;
                    _selectedPiace = null;
                }
                
                if (_selectedPiace != null)
                {
                    Vector3 _touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    _selectedPiace.transform.position = new Vector3(_touchPos.x,_touchPos.y,0);
                }
                break;
            
            case 2:
                
                if (Input.GetMouseButtonUp(0))
                {
                    _selectedPiace.GetComponent<PieceManager>().selected = false;
                    _selectedPiace = null;
                }
                
                if (_selectedPiace != null)
                {
                    Vector3 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _selectedPiace.transform.position = new Vector3(_mousePos.x, _mousePos.y,0);
                }
                break;
        }
        
    }
}