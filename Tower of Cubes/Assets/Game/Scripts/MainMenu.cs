using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public SoundManager sound;
    public LevelLoader loader;

    public static bool playButton;

    public List<Button> levelButton;

    public void PlayButton()
    {
        if(PlayerPrefs.GetInt("level", 0) == 0) 
        {
            Tutorial.instance.ActivateTutorial();
            sound.ButtonTap();
            loader.SwitchPanels();
        } 
        else 
        {
            playButton = true;
            sound.ButtonTap();
            adjustCapButton();
            loader.SwitchPanels();
        }
    }

    // public void TutorialButton()
    // {
    //     Tutorial.instance.ActivateTutorial();
    //     sound.ButtonTap();
    //     loader.SwitchPanels();
    // }

    public void Tutorial_next_Button()
    {
        sound.ButtonTap();
        CrossSceneInfo.ChosenLevel = 0;
        //Tutorial activate
        loader.LoadGame();
    }

    public void Level_1_Button()
    {
        sound.ButtonTap();
        CrossSceneInfo.ChosenLevel = 1;
        //Tutorial activate
        loader.LoadGame();
    }

    public void Level_2_Button()
    {
        sound.ButtonTap();
        CrossSceneInfo.ChosenLevel = 2;
        loader.LoadGame();
    }

    public void Level_3_Button()
    {
        sound.ButtonTap();
        CrossSceneInfo.ChosenLevel = 3;
        loader.LoadGame();
    }

    public void Level_4_Button()
    {
        sound.ButtonTap();
        CrossSceneInfo.ChosenLevel = 4;
        loader.LoadGame();
    }

    public void Level_5_Button()
    {
        sound.ButtonTap();
        CrossSceneInfo.ChosenLevel = 5;
        loader.LoadGame();
    }

    public void adjustCapButton() 
    {
        int level = PlayerPrefs.GetInt("level", 0);
        for (int i = 0; i < level; i++)
        {
            levelButton[i].interactable = true;
        }
    }



}
