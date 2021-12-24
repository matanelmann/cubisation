using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    public InputManager input;
    public SoundManager sound;
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
        Debug.Log("Init of GameHandler");
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

    public void Restart()
    {
        active = false;
        DestroyObjects();
        StartGame();
    }

    public void GameOver()
    {
        // To-do
        level.cc.CancelInvoke();
        active = false;
        Debug.Log("Game Over");
    }

    public void LevelPassed()
    {
        // To-do
        active = false;
        sound.LevelPassed();
        Debug.Log("Level Passed");
        //NextLevel.instance.passToNextLevel();
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
