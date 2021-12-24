using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SoundManager sound;
    public LevelLoader loader;

    public void PlayButton()
    {
        sound.ButtonTap();
        loader.SwitchPanels();
    }

    public void Level_1_Button()
    {
        sound.ButtonTap();
        CrossSceneInfo.ChosenLevel = 1;
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


}
