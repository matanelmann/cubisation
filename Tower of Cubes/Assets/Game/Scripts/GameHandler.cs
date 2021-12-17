using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    private bool active;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    // Temporary:
    private void Start()
    {
        StartGame();
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
        Tower.Instance.init();
        PlayerCube.instance.init();
        MainMenu.Display();
    }

    public void StartGame()
    {
        Tower.Instance.CreateTower();
        Platform.Instance.CreatePlatform();
        PlayerCube.instance.CreatePlayerCube();
    }

    void Update()
    {
        if (active)
        {
            PlayerCube.instance.CheckInput();
            Tower.Instance.UpdateTower();
        }
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

    public void CheckPhase()
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
    }

    public bool isGameActive()
    {
        return active;
    }
}
