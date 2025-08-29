using System.Timers;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 240;
    public bool timerIsActive = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

            }
            else
            {
                timeRemaining = 0;
                timerIsActive = false;

                if (timeRemaining == 0)
                {
                    SceneManager.LoadScene("Victory");
                }
            }
        }
    }
}
