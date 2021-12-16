using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    [HideInInspector] public CubeClass.Cube cubeObj;
    Rigidbody2D cubeRb;
    void Start()
    {
        cubeRb = gameObject.GetComponent<Rigidbody2D>();
        cubeRb.gravityScale = GameSettings.CUBE_GRAVITY;
        cubeRb.mass = GameSettings.CUBE_MASS;
    }

    void Update()
    {
        if (cubeOutOfBounds())
        {
            
            Destroy(gameObject);
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
}
