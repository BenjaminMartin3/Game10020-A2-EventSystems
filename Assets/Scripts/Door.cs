using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Door : MonoBehaviour
{
    // Sprites for Door States; 
    public Sprite closedDoor;
    public Sprite openDoor;

    // Bool for Door's current active state
    public bool closedState = true;

    // Components on the Door object
    SpriteRenderer spriteRenderer;
    Collider2D Collider; 

    private void Awake()
    {
        // Get the components off the Door object
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();
    }

    public void UpdateState()
    {
        // Toggle sprite when active state changes
        spriteRenderer.sprite = closedState ? closedDoor : openDoor;

        // Enable/Disable collider when active state changes
        if (closedState == true)
        {
            Collider.enabled = true;
        }
        if (closedState == false)
        {
            Collider.enabled = false;
        }
    }
    public void DoorState()
    {
        // Toggle state to the opposite one 
        closedState = !closedState;
        UpdateState(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Load Win Scene if touched when Door is open 
        if (collision.gameObject.CompareTag("Player") && closedState == false)
        {
            SceneManager.LoadScene("Win"); 
        }
    }
}
