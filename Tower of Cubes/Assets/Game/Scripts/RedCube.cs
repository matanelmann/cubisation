using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    Rigidbody2D cubeRb;
    void Start()
    {
        cubeRb = gameObject.GetComponent<Rigidbody2D>();
        cubeRb.gravityScale = GameSettings.CUBE_GRAVITY;
    }
}
