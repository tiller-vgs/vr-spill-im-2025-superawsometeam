using System.Threading;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float RemainingTime = 60;
    public TMP_Text messageText;


    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        showCountdown();
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



    private void showCountdown()
    {
        messageText.SetText("Time: " + ((int)RemainingTime).ToString());
    }
}
