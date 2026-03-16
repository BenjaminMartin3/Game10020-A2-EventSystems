using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public LevelManager levelManager;

    public Sprite spikeUp;
    public Sprite spikeDown;

    public int spikeDamage = 1; 
    public bool spikeActive = true;
    SpriteRenderer spriteRenderer;
    Collider2D Collider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider = GetComponent<Collider2D>();  
    }

    private void UpdateState()
    {
        spriteRenderer.sprite = spikeActive ? spikeUp : spikeDown;
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
        spikeActive = !spikeActive;
        UpdateState();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.LowerHP(spikeDamage);
        }

    }

}
