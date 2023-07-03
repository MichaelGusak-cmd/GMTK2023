using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadOnlyAttribute : PropertyAttribute { }

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;
    public float timeScale = 1; // view only
    public GameObject pauseMenu;

    private static float previousTimeScale = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        bool prevPaused = isPaused;
        isPaused = Time.timeScale > 0;

        if (prevPaused != isPaused)
        {
            AudioListener.pause = isPaused;
            pauseMenu.SetActive(isPaused);

            previousTimeScale = isPaused ? Time.timeScale : previousTimeScale;
            Time.timeScale = isPaused ? 0 : previousTimeScale;
            timeScale = Time.timeScale;
        }
    }
}
