using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events; 

public class Button : MonoBehaviour
{
    // Sprites for the Button's States
    public Sprite inactiveState;
    public Sprite pressedDown; 

    // Unity Event for when Button is pressed down 
    public UnityEvent<bool> OnPressed;

    // Components of the Button object
    SpriteRenderer spriteRenderer; 

    // Bool for if button is in presse state
    bool pressedState = false;

    private void Awake()
    {
        // Getting components 
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Make sure Unity Event is active 
        if (OnPressed == null)
        {
            OnPressed = new UnityEvent<bool>();
        }
    }

    public void PressedState()
    {
        // Toggle sprite when pressed state changes
        spriteRenderer.sprite = pressedState ? pressedDown : inactiveState;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When anything enters the Button's trigger, change state and Invoke Unity Event 
        if (collision.gameObject)
        {
            pressedState = true;
            PressedState();
            OnPressed.Invoke(pressedState);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        // When anything exits the Button's trigger, change state and Invoke Unity Event 
        if (collision.gameObject)
        {
            pressedState = false;
            PressedState();
            OnPressed.Invoke(pressedState);
        }
    }
}
