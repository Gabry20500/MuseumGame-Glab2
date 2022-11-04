using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndRotate : MonoBehaviour
{

    public float rotationSpeed = 1000f;

    private float _startingPositionX;
    private float _startingPositionY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startingPositionX = touch.position.x;
                    _startingPositionY = touch.position.y;
                    break;
                case TouchPhase.Moved:
                    if (_startingPositionX > touch.position.x)
                    {
                        transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
                    }else if (_startingPositionY > touch.position.y)
                    {
                        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
                    }
                    else if (_startingPositionX < touch.position.x)
                    {
                        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
                    }else if (_startingPositionY < touch.position.y)
                    {
                        transform.Rotate(Vector3.down, -rotationSpeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Stationary:
                    _startingPositionX = touch.position.x;
                    _startingPositionY = touch.position.y;
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    break;
            }
        }
    }
    // float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        // float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        //
        // transform.RotateAround(Vector3.down, XaxisRotation);
        // transform.RotateAround(Vector3.right, YaxisRotation);
}
