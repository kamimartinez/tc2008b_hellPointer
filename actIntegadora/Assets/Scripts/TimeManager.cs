using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnSecondChanged;
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int Second { get; private set; } 
    public static int Minute{get; private set;}
    public static int Hour{get;private set;}

    private float timer;

    void Start()
    {   
        Second = 0;
        Minute = 0;
        Hour = 10;
        timer = 1f;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            Second++;
            Debug.Log("Tick: " + Second);
            OnSecondChanged?.Invoke();

            if(Second >= 60)
            {
                Minute++;
                OnMinuteChanged?.Invoke();
                Second = 0;
            }

            if (Minute >= 60) {
                Hour++;
                OnHourChanged?.Invoke();
                Minute = 0;
            }

            timer = 1f;
        }
    }
}
