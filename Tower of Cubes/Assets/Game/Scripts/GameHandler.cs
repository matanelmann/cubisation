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
        CodeMonkey.CMDebug.TextPopup("Welcome to Red Cube Tower! \nYour goal on each level is to replace all \nthe red cubes of the \ntower with blue cubes", new Vector3(GameSettings.LEFT_EDGE, 0, 0), 10f, 25, Color.green);
        CodeMonkey.CMDebug.TextPopup("Place your finger on the blue cube \nand drag to the left to shoot \nand replace the top \nred cube of the tower", new Vector3(GameSettings.LEFT_EDGE, -20, 0), 10f, 25, Color.green);
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

    public static void RestartLevel()
    {
        Tower.DestroyTower();
        PlayerCube.DestroyPlayer();
        Tower.CreateTower();
        PlayerCube.CreatePlayerCube();
    }
    
    public static void DisplayText(string str, Vector3 position, int fontSize)
    {
        CodeMonkey.CMDebug.TextPopup(str, position, 10f, 25, Color.green);
    }
}
