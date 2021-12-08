using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public List<Cube> cubesList;

    void Awake() {
        cubesList = new List<Cube>();
        CreateBuilding();
    }

    public int GetTowerLength() {
        return cubesList.Count;
    }

    private void CreateCube(float yPosition, float cubeScale)
    {
        Transform cubeTransform = Instantiate(GameAssets.GetInstance().redCube, transform.parent);
        cubeTransform.position = new Vector3(GameSettings.TOWER_X, yPosition);
        cubeTransform.localScale = new Vector3(cubeScale, cubeScale, cubeScale);
        Cube cube = new Cube(cubeTransform);

        cubesList.Add(cube);
    }

    private void CreateBuilding()
    {
        for (int i = 0; i < GameSettings.TOWER_HEIGHT; i++)
        {
            CreateCube(GameSettings.TOWER_ROOT_Y + i * 2 * GameSettings.CUBE_LENGTH, GameSettings.CUBE_SCALE);
        }
    }

    public class Cube
    {
        public Transform cubeTransform;
        public Cube(Transform cubeTransform)
        {
            this.cubeTransform = cubeTransform;
        }
        public Transform getTransform()
        {
            return this.cubeTransform;
        }
    }
}
