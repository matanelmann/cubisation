using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public GameObject mainPanel;
    public GameObject levelsPanel;

    public void SwitchPanels()
    {
        transition.SetTrigger("Start");
        Invoke("switchPanels", 0.5f);
    }

    private void switchPanels()
    {
        if (mainPanel.activeInHierarchy)
        {
            mainPanel.SetActive(false);
            levelsPanel.SetActive(true);
        }
        else
        {
            levelsPanel.SetActive(false);
            mainPanel.SetActive(true);
        }
        transition.SetTrigger("End");
    }

    public void LoadGame()
    {
        StartCoroutine(loadGame());
    }

    IEnumerator loadGame()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
