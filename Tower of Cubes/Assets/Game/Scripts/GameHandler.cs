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
        Debug.Log("Init of GameHandler");
        active = false;
        level = Level.GetInstance();
        CubesController.GetInstance().Init();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
        NextLevel.instance.passToNextLevel();
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
