using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level instance;
    public int LevelNum;
    public LevelSettings.GameSet ST;

    private void Awake()
    {
        instance = this;
    }

    public static LevelSettings.GameSet GetSettings()
    {
        return instance.ST;
    }

    public static Level GetInstance()
    {
        return instance;
    }

    public void StartLevel(int LevelNum)
    {
        this.LevelNum = LevelNum;
        ST = LevelSettings.Get(LevelNum);
        Debug.Log("Building Tower and player");
        buildTower();
        SpawnNewPlayer();
    }

    private void buildTower()
    {
        float scale, length;
        for (int i = 0; i < ST.TOWER_HEIGHT; i++)
        {
            scale = ST.CUBE_ROOT_SCALE * Mathf.Pow(ST.SCALE_DECREASE_RATE, i);
            length = scale * 5.12f;
            CubesController.GetInstance().CreateCube(Cube.Type.Red, new Vector3(GameConfig.TOWER_X - length / 2, GetTowerHeight()), Vector3.one * scale);
        }
    }

    public void SpawnNewPlayer()
    {
        CubesController.GetInstance().CreateBlueCube();
    }

    public float GetTowerHeight()
    {
        float result = 0;
        foreach (Cube cube in CubesController.GetInstance().RedCubes)
        {
            result += cube.scale;
        }
        return GameConfig.GROUND_Y + Mathf.Abs(result * 5.12f);
    }

    public bool TowerEmpty()
    {
        if (CubesController.GetInstance().RedCubes.Count == 0)
        {
            return true;
        }
        return false;
    }
}
