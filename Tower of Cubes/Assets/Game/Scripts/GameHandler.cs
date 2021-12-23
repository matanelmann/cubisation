using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    public InputManager input;
    public SoundManager sound;
    private Level level;
    private bool active;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    // Temporary:
    private void Start()
    {
        StartGame(); // Should later on be called from the main menu at first!
    }

    public static GameHandler GetInstance()
    {
        return Instance;
    }

    private void Init() {
        active = false;
        level = Level.GetInstance();
        CubesController.GetInstance().Init();
        //MainMenu.Display();
    }

    public void StartGame()
    {
        active = true;
        Level.GetInstance().StartLevel(0);
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
