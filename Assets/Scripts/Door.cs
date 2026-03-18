using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Door : MonoBehaviour
{
    public Sprite closedDoor;
    public Sprite openDoor;

    public bool closedState = true;
    SpriteRenderer spriteRenderer;
    Collider2D Collider; 

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();
    }

    public void UpdateState()
    {
        spriteRenderer.sprite = closedState ? closedDoor : openDoor;
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
        closedState = !closedState;
        UpdateState(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && closedState == false)
        {
            SceneManager.LoadScene("Win"); 
        }
    }
}
