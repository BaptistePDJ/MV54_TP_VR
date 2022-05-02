using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsBehavior : MonoBehaviour
{
    public Animator rightAnimator;
    public Animator rightHandAnimator;
    public GameObject rightThumbstick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("A Pressed");
            if (rightAnimator)
            {
                rightAnimator.SetBool("APressed", true);
            }
        }
        if (context.canceled)
        {
            Debug.Log("A Released");
            if (rightAnimator)
            {
                rightAnimator.SetBool("APressed", false);
            }
        }

    }
    public void OnBPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("B Pressed");
            if (rightAnimator)
            {
                rightAnimator.SetBool("BPressed", true);
            }
        }
        if (context.canceled)
        {
            Debug.Log("B Released");
            if (rightAnimator)
            {
                rightAnimator.SetBool("BPressed", false);
            }
        }
    }
    public void OnTriggerAxis(InputAction.CallbackContext context)
    {
        if (rightAnimator)
        {
            rightAnimator.SetFloat("RightTrigger", context.ReadValue<float>());
        }
    }
    public void OnThumbstickAxis(InputAction.CallbackContext context)
    {
        if (rightThumbstick)
        {
            Vector2 thumbstickValue = context.ReadValue<Vector2>();
            rightThumbstick.transform.localEulerAngles = new Vector3(0, 90 + thumbstickValue.x , -
           thumbstickValue.y) * 15f;
        }
    }

    public void OnGripAxis(InputAction.CallbackContext context)
    {
        if (rightHandAnimator)
        {
            rightHandAnimator.SetFloat("Close", context.ReadValue<float>());
        }
    }
    public void OnTriggerTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (rightHandAnimator)
            {
                Debug.Log("Trigger release");
                rightHandAnimator.SetBool("Point", false);
            }
        }
        if (context.canceled)
        {
            if (rightHandAnimator)
            {
                Debug.Log("Trigger touch");
                rightHandAnimator.SetBool("Point", true);
            }
        }
    }
}
