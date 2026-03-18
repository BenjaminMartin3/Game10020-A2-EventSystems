using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Get the LevelManager script
    public LevelManager levelManager;

    // Sprites for the Spikes states
    public Sprite spikeUp;
    public Sprite spikeDown;

    // Int for the damage the Spike does 
    public int spikeDamage = 1; 

    // Bool for the current active state of the Spike
    public bool spikeActive = true;

    // Components on the Spike object
    SpriteRenderer spriteRenderer;
    Collider2D Collider;

    private void Awake()
    {
        // Getting these componets off the Spike object
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();  
    }

    private void UpdateState()
    {
        // Toggle the Spike sprite to the opposite one
        spriteRenderer.sprite = spikeActive ? spikeUp : spikeDown;

        // Enable/Disable the Spike damage trigger
        if (spikeActive == true)
        {
            Collider.enabled = true;
        } 
        if (spikeActive == false)
        {
            Collider.enabled = false;   
        }
    }

    public void SpikeState()
    {
        // Change active state to the opposite one 
        spikeActive = !spikeActive;
        UpdateState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When player collides with damage trigger, lower the player's HP by the Spike's damage
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.LowerHP(spikeDamage);
        }

    }

}
