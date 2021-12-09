using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static bool Play = true;
    void Start()
    {
        Tower.CreateTower();
        Platform.CreatePlatform();
        PlayerCube.CreatePlayerCube();
    }

    // Update is called once per frame
    void Update()
    {
        if (Play)
        {
            Tower.UpdateTower();
        }
    }

    public static void GameOver()
    {
        // To-do
        Play = false;
        Debug.Log("Game Over");
    }
}
