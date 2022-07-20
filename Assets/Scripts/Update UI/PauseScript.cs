using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool ispaused = false;

    public void PauseScreen()
    {
        if (ispaused)
        {
            Time.timeScale = 1f;
            ispaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            ispaused = true;
        }
    }
}
