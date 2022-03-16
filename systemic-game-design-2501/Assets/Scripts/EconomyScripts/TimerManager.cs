using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public void PauseTime()
    {
        if (Time.timeScale == 1.0f)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }

    public void ResumeTime()
    {
        if (Time.timeScale != 1.0f)
            Time.timeScale = 1.0f;
        else
            Time.timeScale = 0.0f;
    }


}
