using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    static AudioSource sound;
    public static bool Play = true;
    void Start()
    {
        Tower.CreateTower();
        Platform.CreatePlatform();
        PlayerCube.CreatePlayerCube();
        sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Play)
        {
            PlayerCube.CheckInput();
            Tower.UpdateTower();
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
}
