using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Get PlayerMovement Script
    public PlayerMovement playerMovement;

    // Sprites for Teleporter Toggle
    public Sprite teleportOn;
    public Sprite teleportOff;

    // Bool for active state of Teleporter
    public bool teleportActive = false;

    // Componets on the Teleporter Object
    SpriteRenderer spriteRenderer;
    Collider2D Collider;

    private void Awake()
    {
        // Getting these components so they are avalible when the game starts
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();
    }

    public void UpdateState()
    {
        // Change sprite when UpdateState() is called
        spriteRenderer.sprite = teleportActive ? teleportOn : teleportOff;

        // Enable/Disable the Collider Component when active state changes
        if (teleportActive == true)
        {
            Collider.enabled = true;
        }
        if (teleportActive == false)
        {
            Collider.enabled = false;
        }
    }

    public void TeleportState()
    {
        // Change Teleporter state to the opposite of what it currently is
        teleportActive = !teleportActive;
        UpdateState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Reset Player position to its start position 
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.transform.position = playerMovement.originPosition;
        }
    }
}
