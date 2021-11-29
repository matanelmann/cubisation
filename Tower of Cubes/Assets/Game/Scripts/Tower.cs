using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private List<Cube> cubesList;
    void Start()
    {
        cubesList = new List<Cube>();
        CreateBuilding();
    }
    private void CreateCube(float yPosition)
    {
        Transform cubeTransform = Instantiate(GameAssets.GetInstance().redCube, transform.parent);
        cubeTransform.position = new Vector3(GameSettings.TOWER_X, yPosition);
        cubeTransform.localScale = new Vector3(GameSettings.CUBE_SCALE, GameSettings.CUBE_SCALE, GameSettings.CUBE_SCALE);
        Cube cube = new Cube(cubeTransform);

        cubesList.Add(cube);
    }

    private void CreateBuilding()
    {
        for (int i = 0; i < GameSettings.TOWER_HEIGHT; i++)
        {
            CreateCube(GameSettings.TOWER_ROOT_Y + i * 2 * GameSettings.CUBE_LENGTH);
        }
    }

    private class Cube
    {
        private Transform cubeTransform;
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
