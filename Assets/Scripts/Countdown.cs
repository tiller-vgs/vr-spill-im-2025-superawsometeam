using System.Threading;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private int timerDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerDown = 60;
        InvokeRepeating("Subtract", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timerDown);
    }

    void Subtract()
    {
        timerDown -= 1;
        
    }
}
