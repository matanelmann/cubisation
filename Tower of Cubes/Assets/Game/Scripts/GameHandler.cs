using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    public InputManager input;
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



    // void Start()
    // {
    //     Play = true;
    //     Tower.CreateTower();
    //     Platform.CreatePlatform();
    //     PlayerCube.CreatePlayerCube();
    //     sound = gameObject.GetComponent<AudioSource>();
    // }
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
            //Tower.Instance.UpdateTower();
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
        active = false;
        Debug.Log("Game Over");
    }

    public void LevelPassed()
    {
        // To-do
        active = false;
        Debug.Log("Level Passed");
    }

    /*public void CheckPhase()
    {
        if (Tower.Instance.newTopCube)
        {
            Tower.Instance.newTopCube = false;
            Platform.Instance.MovePlatform();
        }
        else
        {
            GameOver();
        }
    }*/

    public bool isGameActive()
    {
        return active;
    }

    private void DestroyObjects()
    {
        level.Clear();
    }
}
