using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
    
    private TouchControls _touchControls;
    private Camera _mainCamera;

    private void Awake()
    {
        _touchControls = new TouchControls();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _touchControls.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _touchControls.Touch.TouchPress.started += StartTouch;
        _touchControls.Touch.TouchPress.canceled += EndTouch;
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started " + _touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        OnStartTouch?.Invoke(_touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float) context.startTime);
    }
    
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended " + _touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        DetectObject();
        OnEndTouch?.Invoke(_touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float) context.time);
    }

    private void DetectObject()
    {
        //3d
        var ray = _mainCamera.ScreenPointToRay(_touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider != null)
            {
                Debug.Log("3d hit: " + hit.collider.tag);
                if (hit.collider.CompareTag("Button"))
                {
                    hit.collider.gameObject.GetComponent<TapButton>().ButtonTapped();
                    hit.collider.gameObject.GetComponent<TapButton>().ButtonUnTapped();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
