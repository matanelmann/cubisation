using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Animation anim;
    public GameObject firstInstructionsPanel;
    public GameObject tooStrongPanel;
    public GameObject blueCubesPanel;
    public GameObject greatJobPanel;
    public GameObject FinishPanel;
    public GameObject tooWeakPanel;
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
        finger.position = new Vector3(mainBlue.cubeTransform.position.x * -1.2f, mainBlue.cubeTransform.position.y + mainBlue.length * 1.65f);
        fadeIn();
    }
    public void HideFirstInstructions()
    {
        firstInstructionsPanel.SetActive(false);
    }

    public void ShowTooStrong()
    {
        tooStrongPanel.SetActive(true);
        CancelInvoke();
        HideFirstInstructions();
        fadeIn();
    }
    public void ShowTooWeak()
    {
        tooWeakPanel.SetActive(true);
        fadeIn();
    }

    public void ShowBlueCubes()
    {
        blueCubesPanel.SetActive(true);
        fadeIn();
    }

    public void ShowGreatJob()
    {
        greatJobPanel.SetActive(true);
        fadeIn();
    }
    public void HideGreatJob()
    {
        greatJobPanel.SetActive(false);
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
        tooWeakPanel.SetActive(false);
        blueCubesPanel.SetActive(false);
        greatJobPanel.SetActive(false);
        FinishPanel.SetActive(false);
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

