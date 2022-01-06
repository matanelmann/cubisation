using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeState
{
    public float xPos;
    public bool main;
    public CubeState(Cube cube)
    {
        this.xPos = cube.cubeTransform.position.x;
        this.main = cube.isMain();
    }
}
