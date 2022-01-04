using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Animation anim;
    public GameObject firstInstructionsPanel;
    public GameObject tooStrongPanel;
    public GameObject greatJobPanel;
    public GameObject FinishPanel;
    private Transform finger;

    public static TutorialManager instance;
    private void Awake()
    {
        instance = this;
        finger = firstInstructionsPanel.transform.GetChild(0); // Get the finger's transform
    }

    public void ShowFirstInstructions(Cube mainBlue)
    {   
        firstInstructionsPanel.SetActive(true);
        finger.position = new Vector3(mainBlue.cubeTransform.position.x, mainBlue.cubeTransform.position.y);
        fadeIn();
    }

    public void ShowTooStrong()
    {
        tooStrongPanel.SetActive(true);
        fadeIn();
    }

    public void ShowGreatJob()
    {
        greatJobPanel.SetActive(true);
        fadeIn();
    }
    public void ShowFinishJob()
    {
        FinishPanel.SetActive(true);
        fadeIn();
    }

    public void Clear()
    {
        Time.timeScale = 1;
        finger.GetChild(0).GetComponent<Animation>().Stop();
        fadeOut();
        Invoke("clear", 0.5f);
    }

    private void clear()
    {
        firstInstructionsPanel.SetActive(false);
        tooStrongPanel.SetActive(false);
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

