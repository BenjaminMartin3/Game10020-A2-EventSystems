using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    // Unity Event for when Timer Laps
    public UnityEvent<bool> OnTimerLap;
    
    // Float for Timer's max time 
    public float timerMaxTime = 5f;

    // Float for Timer's current time
    float timerTime;

    // Float of Timer's time rounded
    float timerRounded; 

    // Bool state of current timer lap
    public bool timerLappedState = true;

    private void Awake()
    {
        // Make sure Unity Event is active 
        if (OnTimerLap == null)
        {
            OnTimerLap = new UnityEvent<bool>();
        }
    }

    private void Start()
    {
        // Set Timer's current time to the max time
        timerTime = timerMaxTime; 
    }

    private void Update()
    {
        // Subtract Timer time by Delta Time
        timerTime = timerTime - Time.deltaTime;

        // When timer reaches 0, toggle bool state, invoke the Unity Event, and reset 
        if (timerTime <= 0)
        {
            timerLappedState = !timerLappedState;
            OnTimerLap.Invoke(timerLappedState);
            timerTime = timerMaxTime; 
        }
    }
}
