using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesController : MonoBehaviour
{
    private static CubesController instance;
    private static SoundManager sound;
    [HideInInspector] public List<Cube> BlueCubes, RedCubes;
    private Cube mainBlue;
    private Cube mainRed;
    private Cube temp;
    public TutorialManager tm;
    public LevelLoader loader;

    private void Awake()
    {
        instance = this;
    }
    public static CubesController GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        if (GameHandler.GetInstance().isGameActive())
        {
            updateCubes();
        }
    }

    public void Init()
    {
        BlueCubes = new List<Cube>();
        RedCubes = new List<Cube>();
        sound = SoundManager.GetInstance();
    }

    public void CreateCube(Cube.Type type, Vector3 position, Vector3 scale)
    {
        Cube newCube;
        if (type == Cube.Type.Blue)
        {
            newCube = new Cube(Instantiate(GameAssets.instance.blueCube, GameConfig.GameTransform), type, position, scale, instance, sound);
            mainBlue = newCube;
            BlueCubes.Add(newCube);
        }
        else
        {
            newCube = new Cube(Instantiate(GameAssets.instance.redCube, GameConfig.GameTransform), type, position, scale, instance, sound);
            mainRed = newCube;
            RedCubes.Add(newCube);
        }
    }

    public Cube GetLast(Cube.Type type)
    {
        if (type == Cube.Type.Red)
        {
            return getCubeByIndex(RedCubes, 0);
        }
        else
        {
            return getCubeByIndex(BlueCubes, 0);
        }
    }

    public Cube GetSecondToLast(Cube.Type type)
    {
        if (type == Cube.Type.Red)
        {
            return getCubeByIndex(RedCubes, 1);
        }
        else
        {
            return getCubeByIndex(BlueCubes, 1);
        }
    }

    private Cube getCubeByIndex(List<Cube> cubes, int index)
    {
        if (cubes.Count == 0)
        {
            return null;
        }
        return cubes[cubes.Count - 1 - index];
    }

    public Cube GetMainBlue()
    {
        return mainBlue;
    }

    public Cube GetMainRed()
    {
        return mainRed;
    }

    private void checkCubesBounds(List<Cube> cubes)
    {
        List<Cube> removeList = new List<Cube>();
        foreach (Cube cube in cubes)
        {
            if (cube.outOfBounds())
            {
                if (cube.type == Cube.Type.Blue)
                {
                    GameHandler.GetInstance().GameOver(new CubeState(cube));
                }
                removeList.Add(cube);
                Destroy(cube.gameObj);
            }
            else if (cube.type == Cube.Type.Blue && cube.OffTower())
            {
                Debug.Log("Here!");
                GameHandler.GetInstance().GameOver(new CubeState(cube));
            }
        }
        foreach (Cube cube in removeList)
        {
            cubes.Remove(cube);
        }
        //if (removeList.Count > 0 && cubes == BlueCubes)
        //{
        //    GameHandler.GetInstance().GameOver(new CubeState(cube));
        //}
    }

    private void updateMainRed()
    {
        if (mainRed != null && mainRed.OffTower())
        {
            mainBlue.allowCollision = false;
            mainRed = mainRed.prevCube;
        }
    }

    private void updateCubes()
    {
        checkCubesBounds(BlueCubes);
        checkCubesBounds(RedCubes);
        updateMainRed();
    }

    public void StartPhaseCompletionTimer()
    {
        temp = mainRed;
        Invoke("ReportPhaseCompletion", 2f);
    }

    private void ReportPhaseCompletion()
    {
        if (RedCubes.Count == 0)
        {
            GameHandler.GetInstance().LevelPassed();
        }
        else if (temp != mainRed)
        {
            Level.GetInstance().MovePlatform();
        }
    }

    private void DestroyCubes(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if (cube.gameObj)
            {
                Destroy(cube.gameObj);
            }
        }
        cubes.Clear();
    }

    public void DestroyAll()
    {
        DestroyCubes(BlueCubes);
        DestroyCubes(RedCubes);
        CancelInvoke();
    }

    private void getTooStrong()
    {
        GameHandler.GetInstance().tooStrong();
    }
}
