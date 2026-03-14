using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events; 

public class Button : MonoBehaviour
{
    public Sprite inactiveState;
    public Sprite pressedDown; 

    public UnityEvent<bool> OnPressed;

    SpriteRenderer spriteRenderer; 

    bool pressedState = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (OnPressed == null)
        {
            OnPressed = new UnityEvent<bool>();
        }
    }

    private void Update()
    {
        if (pressedState == false)
        {
            Debug.Log("Inactive");
        }
    }

    public void PressedState()
    {
        spriteRenderer.sprite = pressedState ? pressedDown : inactiveState;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            pressedState = true;
            Debug.Log("PressedDown");
            PressedState();
            OnPressed.Invoke(pressedState);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            pressedState = false;
            PressedState();
            OnPressed.Invoke(pressedState);
        }
    }
}
