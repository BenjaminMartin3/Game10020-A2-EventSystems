using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    // Unity Event for when object is collected
    public UnityEvent<bool> OnCollected;

    // Bool for collected state
    bool collectState = false;

    private void Awake()
    {
        // Make sure Unity Event is active
        if (OnCollected == null)
        {
            OnCollected = new UnityEvent<bool>(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When player "collects" object, Invoke Unity Event and destory the GameObject
        if (collision.gameObject.CompareTag("Player"))
        {
            collectState = true;
            OnCollected.Invoke(collectState); 
            Destroy(gameObject); 
        }
    }
}
