using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Vector2 for the Box's spawn location
    Vector2 originPosition;

    // Bool for there is a call for the Box to be reset 
    public bool boxNeedsReset = false;

    private void Start()
    {
        // Get the Box's spawn location for later use 
        originPosition = transform.position;
    }

    private void Update()
    {
        // Reset the Box reset call after it has been called
        if (boxNeedsReset == true)
        {
            boxNeedsReset = false;
        }
    }

    public void ResetBox()
    {
        // Alert call for box to be reset
        boxNeedsReset = true;

        // Reset box back to orginal spawn location 
        transform.position = originPosition;
    }
}
