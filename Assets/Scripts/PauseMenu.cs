using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject InGameCanvas;

    void Update()
    {
        // if ESC is pressed, unpause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InGameCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void UnPause()
    {
        // called by button to unpause
        InGameCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
