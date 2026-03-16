using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityEvent<bool> OnCollected;

    bool collectState = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collectState = true;
            OnCollected.Invoke(collectState); 
            Destroy(gameObject); 
        }
    }
}
