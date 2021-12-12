using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    AudioSource sound;
    public static bool allowSound = true;
    public static float initial_Y;
    private static ContactPoint2D[] contacts = new ContactPoint2D[10];
    private static float length;

    private void Start()
    {
        length = transform.localScale.x * 5.12f;
        initial_Y = transform.position.y;
        sound = gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.GetContacts(contacts);
        if (!Tower.TowerEmpty() && allowSound && col.collider.transform == Tower.getTopCube()[0].cubeTransform && SideCollision(contacts)) // If the PlayerCube hit the top RedCube
        {
            sound.Play();
            allowSound = false;
            Invoke("CallMovePlatform", 2f);
        }
    }

    
    void Update()
    {
        if (cubeOutOfBounds())
        {
            if(PlayerCube.popupIndex == 1) {
                
                //text to strong
                Tower.DestroyTower();
                PlayerCube.DestroyPlayer();
                Tower.CreateTower();
                PlayerCube.CreatePlayerCube();

            }
            // Destroy(gameObject);
            // Debug.Log("cubeOutOfBounds");
            // GameHandler.GameOver();
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
        if (transform.position.y < initial_Y - GameSettings.CUBE_LENGTH) // If the cube fell down from the tower
        {
            return false;
        }
        return true;
    }

    private void CallMovePlatform()
    {
        if (Tower.newTopCube && cubeOnTower())
        {
            Tower.newTopCube = false;
            //text grat job try again
            Platform.MovePlatform();
        }
        else
        {
            
            //text to gentle
            Tower.DestroyTower();
            PlayerCube.DestroyPlayer();
            Tower.CreateTower();
            PlayerCube.CreatePlayerCube();
            // Debug.Log("CallMovePlatform");
            // GameHandler.GameOver();
        }
    }
    private bool SideCollision(ContactPoint2D[] contacts)
    {
        foreach (ContactPoint2D cp in contacts)
        {
            if (cp.point.y >= transform.position.y + 0.1 * length)
            {
                return true;

            }
        }
        return false;
    }
}