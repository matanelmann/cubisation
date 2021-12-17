using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    static AudioSource sound;
    public static bool Play;
    // void Start()
    // {
    //     Play = true;
    //     Tower.CreateTower();
    //     Platform.CreatePlatform();
    //     PlayerCube.CreatePlayerCube();
    //     sound = gameObject.GetComponent<AudioSource>();
    // }
    public void init() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Play)
        {
            PlayerCube.instance.CheckInput();
            Tower.instance.UpdateTower();
        }
    }

    public static void GameOver()
    {
        // To-do
        Play = false;
        Debug.Log("Game Over");
    }

    public static void LevelPassed()
    {
        // To-do
        sound.Play();
        Play = false;
        Debug.Log("Level Passed");
    }

    public static void CheckPhase()
    {
        if (Tower.instance.newTopCube)
        {
            Tower.instance.newTopCube = false;
            Platform.instance.MovePlatform();
        }
        else
        {
            GameHandler.GameOver();
        }
    }
}
