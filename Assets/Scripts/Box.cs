using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Vector2 originPosition;
    public bool boxNeedsReset = false;

    private void Start()
    {
        originPosition = transform.position;
    }

    private void Update()
    {
        if (boxNeedsReset == true)
        {
            boxNeedsReset = false;
        }
    }

    public void ResetBox()
    {
        boxNeedsReset = true;
        transform.position = originPosition;
    }
}
