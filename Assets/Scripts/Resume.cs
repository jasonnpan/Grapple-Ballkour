using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{

    public void ResumeGame()
    {
        Time.timeScale = 1.2f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
}
