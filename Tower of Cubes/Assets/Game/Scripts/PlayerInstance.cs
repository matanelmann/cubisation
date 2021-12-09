using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    AudioSource sound;
    public static bool allowSound = true;
    public static float initial_Y;

    private void Start()
    {
        initial_Y = transform.position.y;
        sound = gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (allowSound && col.collider.transform == Tower.getTopCube().cubeTransform) // If the PlayerCube hit the top RedCube
        {
            sound.Play();
            allowSound = false;
            Invoke("CallMovePlatform", 2f);
            Debug.Log("COLLISION");
        }
    }
    void Update()
    {
        if (cubeOutOfBounds())
        {
            Destroy(gameObject);
            GameHandler.GameOver();
        }
    }
    private bool cubeOutOfBounds()
    {
        if (transform.position.x > GameSettings.RIGHT_EDGE + GameSettings.CUBE_LENGTH || transform.position.x < GameSettings.LEFT_EDGE - GameSettings.CUBE_LENGTH) // If the cube is out of screen bounds
        {
            return true;
        }
        return false;
    }

    private bool cubeOnTower()
    {
        Debug.Log(initial_Y);
        if (transform.position.y < initial_Y - GameSettings.CUBE_LENGTH) // If the cube fell down from the tower
        {
            return false;
        }
        return true;
    }

    private void CallMovePlatform()
    {
        Debug.Log("newTopCube: " + Tower.newTopCube);
        Debug.Log("cubeOnTower: " + cubeOnTower());
        if (Tower.newTopCube && cubeOnTower())
        {
            Debug.Log("Calling the platform to move");
            Tower.newTopCube = false;
            Platform.MovePlatform();
        }
        else
        {
            GameHandler.GameOver();
        }
    }
}