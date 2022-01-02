using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Animation anim;
    public GameObject firstInstructionsPanel;
    public GameObject tooStorngPanel;
    public GameObject greatJobPanel;
    public GameObject FinishPanel;

    public static TutorialManager instance; 
    private void Awake()
    {
        instance = this;
    }
    
    public void ShowFirstInstructions()
    {
        firstInstructionsPanel.SetActive(true);
        fadeIn();
    }

    public void ShowTooStorng()
    {
        tooStorngPanel.SetActive(true);
        fadeIn();
    }

    public void ShowGreatJob()
    {
        greatJobPanel.SetActive(true);
        fadeIn();
    }
    public void FinishJob()
    {
        FinishPanel.SetActive(true);
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
        firstInstructionsPanel.SetActive(false);
        tooStorngPanel.SetActive(false);
        greatJobPanel.SetActive(false);
        FinishPanel.SetActive(false);
        GameHandler.Instance.active = true;
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

