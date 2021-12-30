using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public Animation anim;
    public GameObject pausePanel;
    public GameObject levelPassedPanel;
    public GameObject gameOverPanel;
    
    public void ShowPause()
    {
        pausePanel.SetActive(true);
        fadeIn();
        Invoke("stopTime", 0.55f);
    }

    public void ShowLevelPassed()
    {
        levelPassedPanel.SetActive(true);
        fadeIn();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        fadeIn();
    }

    public void Clear()
    {
        Time.timeScale = 1;
        fadeOut();
        Invoke("clear", 0.5f);
    }

    private void clear()
    {
        pausePanel.SetActive(false);
        levelPassedPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    private void fadeIn()
    {
        anim.Play("FadeAlpha_in");
    }

    private void fadeOut()
    {
        anim.Play("FadeAlpha_out");
    }

    private void stopTime()
    {
        Time.timeScale = 0;
    }
}
