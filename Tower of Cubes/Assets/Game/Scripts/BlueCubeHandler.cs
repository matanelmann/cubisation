using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCubeHandler : MonoBehaviour
{
    public Cube cube;
    // This script is meant to pass notifications of the cubes collisions
    private void OnCollisionEnter2D(Collision2D col)
    {
        cube.OnCollision(col);
    }
    private void OnMouseOver()
    {
        cube.MouseOver = true;
    }
    private void OnMouseExit()
    {
        cube.MouseOver = false;
    }
}
