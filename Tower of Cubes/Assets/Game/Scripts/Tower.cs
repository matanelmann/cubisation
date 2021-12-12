using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public static List<Cube> cubesList;
    public static bool newTopCube = false;

    public class Cube
    {
        public Transform cubeTransform;
        public float length;
        public Cube(Transform cubeTransform)
        {
            this.cubeTransform = cubeTransform;
            this.length = cubeTransform.localScale.x * 5.12f;
        }
    }

    void Start() {
        cubesList = new List<Cube>();
    }

    public static void CreateTower()
    {
        float scale, length;
        for (int i = 0; i < GameSettings.TOWER_HEIGHT; i++)
        {
            scale = GameSettings.CUBE_SCALE * Mathf.Pow(0.85f, i);
            length = scale * 5.12f;
            CreateCube((GameSettings.TOWER_X - length/2), GetTowerHeight(), scale);
        }
    }

    public static float GetTowerHeight()
    {
        float result = 0;
        foreach (Cube cube in cubesList)
        {
            result += cube.cubeTransform.localScale.x;
        }
        return GameSettings.GROUND_Y + Mathf.Abs(result * 5.12f);
    }

    private static void CreateCube(float xPosition, float yPosition, float cubeScale)
    {
        Transform cubeTransform = Instantiate(GameAssets.GetInstance().redCube, GameSettings.GameTransform);
        cubeTransform.position = new Vector3(xPosition, yPosition);
        cubeTransform.localScale = new Vector3(cubeScale, cubeScale, cubeScale);
        Cube cube = new Cube(cubeTransform);
        cubesList.Add(cube);
    }

    public static Cube[] getTopCube()
    {
        Cube[] cubes = new Cube[2];
        cubes[0] = cubesList[cubesList.Count - 1];
        if (cubesList.Count > 1)
        {
            cubes[1] = cubesList[cubesList.Count - 2];
        }
        return cubes;
    }

    public static Cube getBottomCube()
    {
        return cubesList[0];
    }

    public static bool TowerEmpty()
    {
        return cubesList.Count <= 1;
    }

    public static void UpdateTower()
    {
        if (!TowerEmpty() && getTopCube()[0].cubeTransform.position.x > getTopCube()[1].cubeTransform.position.x + getTopCube()[1].length)
        {
            cubesList.RemoveAt(cubesList.Count - 1);
            newTopCube = true;
            PlayerInstance.allowSound = true;
            if (cubesList.Count == 0)
            {
                GameHandler.LevelPassed();
            }
        }
    }

    public static void DestroyTower()
    {
        foreach (Cube cube in cubesList)
        {
            Destroy(cube.cubeTransform.gameObject);
        }
    }
}
