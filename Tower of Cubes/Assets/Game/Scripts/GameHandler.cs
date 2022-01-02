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
        level.StartLevel(CrossSceneInfo.ChosenLevel);
    }

    public static GameHandler GetInstance()
    {
        return Instance;
    }

    private void Init() {
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
        StartGame();
    }

    public void GameOver()
    {
        TrajectoryLine.EndLine();
        level.cc.CancelInvoke();
        active = false;
        wm.ShowGameOver();
        Debug.Log("Game Over");
    }

    public void LevelPassed()
    {
        active = false;
        sound.LevelPassed();
        wm.ShowLevelPassed();
        Debug.Log("Level Passed");
    }

    public void firstInstructions()
    {
        active = true;
        tm.ShowFirstInstructions();
        Debug.Log("first instructions");
    }

     public void tooStrong()
    {
        active = false;
        tm.ShowTooStorng();
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
        tm.ShowFirstInstructions();
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
