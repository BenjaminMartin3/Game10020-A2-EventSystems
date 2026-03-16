using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent<bool> OnTimerLap;

    
    public float timerMaxTime = 5f;
    float timerTime;
    float timerRounded; 
    public bool timerLapped = true;

    private void Start()
    {
        timerTime = timerMaxTime; 
    }

    private void Update()
    {
        timerTime = timerTime - Time.deltaTime;
        if (timerTime <= 0)
        {
            timerLapped = !timerLapped;
            OnTimerLap.Invoke(timerLapped);
            timerTime = timerMaxTime; 
        }
    }
}
