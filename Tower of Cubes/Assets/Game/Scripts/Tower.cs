using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public List<CubeClass.Cube> RedCubesList;
    public bool newTopCube;
    public static Tower instance;
    private void Awake()
    {
        instance = this;
    }

    public void init()
    {
        newTopCube = false;
        RedCubesList = new List<CubeClass.Cube>();
    }
    public void CreateTower()
    {
        float scale, length;
        for (int i = 0; i < GameSettings.TOWER_HEIGHT; i++)
        {
            scale = GameSettings.CUBE_SCALE * Mathf.Pow(0.9f, i);
            length = scale * 5.12f;
            CreateCube((GameSettings.TOWER_X - length / 2), GetTowerHeight(), scale);
        }
    }

    public float GetTowerHeight()
    {
        float result = 0;
        foreach (CubeClass.Cube cube in RedCubesList)
        {
            result += cube.cubeTransform.localScale.x;
        }
        return GameSettings.GROUND_Y + Mathf.Abs(result * 5.12f);
    }

    private void CreateCube(float xPosition, float yPosition, float cubeScale)
    {
        Transform cubeTransform = Instantiate(GameAssets.instance.redCube, GameSettings.GameTransform);
        cubeTransform.position = new Vector3(xPosition, yPosition);
        cubeTransform.localScale = new Vector3(cubeScale, cubeScale, cubeScale);
        CubeClass.Cube cube = new CubeClass.Cube(cubeTransform);
        RedCubesList.Add(cube);
    }

    public CubeClass.Cube[] getTopCubes()
    {
        CubeClass.Cube[] cubes = new CubeClass.Cube[2];
        cubes[0] = RedCubesList[RedCubesList.Count - 1];
        if (RedCubesList.Count > 1)
        {
            cubes[1] = RedCubesList[RedCubesList.Count - 2];
        }
        return cubes;
    }

    public CubeClass.Cube getBottomCube()
    {
        return RedCubesList[0];
    }

    public bool TowerEmpty()
    {
        return RedCubesList.Count <= 1;
    }

    public void UpdateTower()
    {
        if (!TowerEmpty() && getTopCubes()[0].cubeTransform.position.x > getTopCubes()[1].cubeTransform.position.x + getTopCubes()[1].length)
        {
            RedCubesList.RemoveAt(RedCubesList.Count - 1);
            newTopCube = true;
            PlayerInstance.instance.allowSound = true;
            if (RedCubesList.Count == 0)
            {
                GameHandler.LevelPassed();
            }
        }
    }
}
