using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    AudioSource sound;
    // [HideInInspector] public CubeClass.Cube cubeObj;
    public CubeClass.Cube cube = CubeClass.Cube.instance;
    public bool allowSound;
    public float initial_Y;
    private ContactPoint2D[] contacts;
    private float length;

    public static PlayerInstance instance;
    private void Awake()
    {
        instance = this;
    }
    public void init()
    {
        allowSound = true;
        contacts = new ContactPoint2D[10];
        length = transform.localScale.x * 5.12f;
        initial_Y = transform.position.y;
        sound = gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.GetContacts(contacts);
        if (!Tower.Instance.TowerEmpty() && allowSound && col.collider.transform == Tower.Instance.getTopCubes()[0].cubeTransform && SideCollision(contacts)) // If the PlayerCube hit the top RedCube
        {
            sound.Play();
            allowSound = false;
            Invoke("CallCheckPhase", 2f);
        }
    }


    void Update()
    {
        if (cubeOutOfBounds())
        {
            //CodeMonkey.CMDebug.TextPopup("Too strong, try again", new Vector3(GameSettings.LEFT_EDGE, -20, 0), 3f, 40, Color.green);
            //GameHandler.RestartLevel();
            Destroy(gameObject);
            GameHandler.Instance.GameOver();

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

    private void CallCheckPhase()
    {
        GameHandler.Instance.CheckPhase();
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