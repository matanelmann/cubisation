using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level instance;
    public int LevelNum;
    public LevelSettings.GameSet ST;
    private CubesController cc;
    private Platform platform;

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

    private void init(int LevelNum)
    {
        this.LevelNum = LevelNum;
        ST = LevelSettings.Get(LevelNum);
        cc = CubesController.GetInstance();
    }

    public void StartLevel(int LevelNum)
    {
        init(LevelNum);
        buildTower();
        buildPlatform();
        SpawnNewPlayer();
    }

    private void buildTower()
    {
        float scale, length;
        for (int i = 0; i < ST.TOWER_HEIGHT; i++)
        {
            scale = ST.CUBE_ROOT_SCALE * Mathf.Pow(ST.SCALE_DECREASE_RATE, i);
            length = scale * 5.12f;
            cc.CreateCube(Cube.Type.Red, new Vector3(GameConfig.TOWER_X - length / 2, GetTowerHeight()), Vector3.one * scale);
        }
    }

    private void buildPlatform()
    {
        platform = new Platform(Instantiate(GameAssets.instance.platform, GameConfig.GameTransform), cc, GetTowerHeight());
    }

    public void SpawnNewPlayer()
    {
        cc.CreateCube(Cube.Type.Blue, new Vector3(GameConfig.LEFT_EDGE / 2f, platform.pt.position.y + cc.GetLast(Cube.Type.Red).length / 2), Vector3.one * cc.GetLast(Cube.Type.Red).scale);
    }

    public float GetTowerHeight()
    {
        float height = 0;
        foreach (Cube cube in cc.RedCubes)
        {
            height += cube.scale;
        }
        return GameConfig.GROUND_Y + Mathf.Abs(height * 5.12f);
    }

    public bool TowerEmpty()
    {
        return cc.RedCubes.Count == 0;
    }

    public void Clear()
    {
        cc.DestroyAll();
        Destroy(platform.pt.gameObject);
    }
}
