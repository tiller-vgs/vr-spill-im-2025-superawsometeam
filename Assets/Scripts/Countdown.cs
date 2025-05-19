using System;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float RemainingTime = 60;
    public TMP_Text scoreandtime;
    public TMP_Text HighScoreText;
    public Boolean Morepoints;
    private int points;
    public int HighScore = 0;
    public GameObject SpawnedSushiParent;


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
            var num = 0;
            while (num < SpawnedSushiParent.transform.childCount)
            {
                SpawnedSushiParent.transform.GetChild(num).GetComponent<sushi_script>().MovingList.Clear();
                num++;
            }
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
        HighScoreText.SetText("Highscore: " + HighScore.ToString());
    }
    public void Restart()
    {
        var num = 0;
        while (num < SpawnedSushiParent.transform.childCount)
        {
            SpawnedSushiParent.transform.GetChild(num).GetComponent<sushi_script>().deleate_clone();
            num++;
        }
        Time.timeScale = 1f;
        RemainingTime = 60;
        if(HighScore< points)
        {
            HighScore = points;
        }
        points = 0;
    }
}
