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
        public Cube(Transform cubeTransform)
        {
            this.cubeTransform = cubeTransform;
        }
    }

    void Start() {
        cubesList = new List<Cube>();
    }

    public static void CreateTower()
    {
        for (int i = 0; i < GameSettings.TOWER_HEIGHT; i++)
        {
            CreateCube(GameSettings.TOWER_ROOT_Y + i * 2 * GameSettings.CUBE_LENGTH, GameSettings.CUBE_SCALE);
        }
    }

    private static void CreateCube(float yPosition, float cubeScale)
    {
        Transform cubeTransform = Instantiate(GameAssets.GetInstance().redCube, GameSettings.GameTransform);
        cubeTransform.position = new Vector3(GameSettings.TOWER_X, yPosition);
        cubeTransform.localScale = new Vector3(cubeScale, cubeScale, cubeScale);
        Cube cube = new Cube(cubeTransform);

        cubesList.Add(cube);
    }

    public static Cube getTopCube()
    {
        return cubesList[cubesList.Count - 1];
    }

    public static void UpdateTower()
    {
        if (getTopCube().cubeTransform.position.x > GameSettings.TOWER_X + GameSettings.CUBE_LENGTH)
        {
            cubesList.RemoveAt(cubesList.Count - 1);
            newTopCube = true;
            PlayerInstance.allowSound = true;
            Debug.Log("REPLACED");
        }
    }
}
