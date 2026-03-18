using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public Sprite teleportOn;
    public Sprite teleportOff;

    public bool teleportActive = false;
    SpriteRenderer spriteRenderer;
    Collider2D Collider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();
    }

    public void UpdateState()
    {
        spriteRenderer.sprite = teleportActive ? teleportOn : teleportOff;
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
        teleportActive = !teleportActive;
        UpdateState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.transform.position = playerMovement.originPosition;
        }
    }
}
