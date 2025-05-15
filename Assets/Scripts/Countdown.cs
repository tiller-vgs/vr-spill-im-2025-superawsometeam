using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float RemainingTime = 60;
    public TMP_Text scoreandtime;
    public Boolean Morepoints;
    private int points;


    private void Start()
    {
        Time.timeScale = 1f;
        Morepoints = false;
        points = 0;
    }

    void Update()
    {
        showCountdown();
        countdowntimer();
        updateScore(); 
        
    }

    private void countdowntimer()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;
        }
        else if (RemainingTime <= 0)
        {
            //spawn_restartbotton
            Time.timeScale = 0f;
        }
    }

    private void updateScore()
    {
        if (Morepoints == true)
        {
            Morepoints = false;
            points += 100;
        }
    }


    private void showCountdown()
    {
        scoreandtime.SetText("Points: " + points.ToString() + "   Time: " + ((int)RemainingTime).ToString());
    }
}
