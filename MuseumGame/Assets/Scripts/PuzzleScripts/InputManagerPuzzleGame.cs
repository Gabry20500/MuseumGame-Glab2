using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerPuzzleGame : MonoBehaviour
{
    //Create a reference for a input controller
    private InputControls _inputControls;

    //Inizialize the variable with a Input Controller reference
    private void Awake()
    {
        _inputControls = new InputControls();
    }

    //Create two function for Enable or Disable the input
    public void OnEnable()
    {
        _inputControls.Enable();
    }

    public void OnDisable()
    {
        _inputControls.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _inputControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
    }

    //On the touch call a gameManager function tu increment the number of touch
    private void StartTouch(InputAction.CallbackContext contex)
    {
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
