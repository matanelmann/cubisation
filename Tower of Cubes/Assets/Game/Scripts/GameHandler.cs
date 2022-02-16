using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    public InputManager input;
    public SoundManager sound;
    public WindowManager wm;
    public TutorialManager tm;
    public GameObject pauseButton;
    private Level level;
    private bool active = false;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        active = true;
        pauseButton.SetActive(!CrossSceneInfo.inTutorial);
        level.StartLevel(CrossSceneInfo.ChosenLevel);
    }

    public static GameHandler GetInstance()
    {
        return Instance;
    }

    private void Init()
    {
        active = false;
        level = Level.GetInstance();
        CubesController.GetInstance().Init();
    }

    void Update()
    {
        if (active)
        {
            input.Check();
        }
    }

    public void PauseGame()
    {
        if (active)
        {
            active = false;
            input.Reset();
            wm.ShowPause();
        }
    }

    public void ResumeGame()
    {
        wm.Clear();
        active = true;
    }

    public void Restart()
    {
        active = false;
        DestroyObjects();
        wm.Clear();
        tm.Clear();
        StartGame();
    }

    public void GameOver(CubeState cubeState)
    {
        TrajectoryLine.EndLine();
        level.cc.CancelInvoke();
        active = false;
        Debug.Log("Game Over");
        if (CrossSceneInfo.inTutorial)
        {
            if (cubeState.main)
            {
                if (cubeState.xPos <= GameConfig.TOWER_X)
                {
                    tm.HideGreatJob();
                    tm.ShowTooWeak();
                }
                else
                {
                    Debug.Log("show too strong");
                    tm.HideGreatJob();
                    tm.ShowTooStrong();
                }
            }
            else
            {
                tm.HideGreatJob();
                tm.ShowBlueCubes();
            }
        }
        else
        {
            wm.ShowGameOver();
        }
    }

    public void LevelPassed()
    {
        active = false;
        //sound.LevelPassed();
        wm.ShowLevelPassed();
        int level = PlayerPrefs.GetInt("level", 0);
        if (CrossSceneInfo.ChosenLevel + 1 > level)
        {
            PlayerPrefs.SetInt("level", CrossSceneInfo.ChosenLevel + 1);
        }
        if (CrossSceneInfo.inTutorial)
        {
            CrossSceneInfo.inTutorial = false;
        }
        Debug.Log("Level Passed");
    }

    public void firstInstructions()
    {
        active = true;
        tm.ShowFirstInstructions(level.cc.GetMainBlue());
        Debug.Log("first instructions");
    }

    public void tooStrong()
    {
        active = false;
        tm.ShowTooStrong();
        Debug.Log("too Strong");
    }
    public void graetJob()
    {
        active = false;
        tm.ShowGreatJob();
        Debug.Log("great job");
    }
    public void finishTutorial()
    {
        active = false;
        tm.ShowFinishJob();
        Debug.Log("finish");
    }

    public bool isGameActive()
    {
        return active;
    }

    private void DestroyObjects()
    {
        level.Clear();
    }
}
