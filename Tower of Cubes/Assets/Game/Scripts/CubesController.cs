using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesController : MonoBehaviour
{
    private static CubesController instance;
    [HideInInspector] public List<Cube> BlueCubes, RedCubes;
    private Cube mainBlue;
    private Cube mainRed, secondaryRed;

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
        updateCubes();
    }

    public void Init()
    {
        BlueCubes = new List<Cube>();
        RedCubes = new List<Cube>();
    }

    public void CreateCube(Cube.Type type, Vector3 position, Vector3 scale)
    {
        Cube newCube;
        if (type == Cube.Type.Blue)
        {
            newCube = new Cube(Instantiate(GameAssets.instance.blueCube, GameConfig.GameTransform), type, position, scale, instance);
            mainBlue = newCube;
            BlueCubes.Add(newCube);
        }
        else
        {
            newCube = new Cube(Instantiate(GameAssets.instance.redCube, GameConfig.GameTransform), type, position, scale, instance);
            if (RedCubes.Count > 0)
            {
                secondaryRed = mainRed;
            }
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
                removeList.Add(cube);
                Destroy(cube.gameObj);
            }
        }
        foreach (Cube cube in removeList)
        {
            cubes.Remove(cube);
        }
    }
    
    private void updateMainRed()
    {
        if (mainRed != null && mainRed.OffTower())
        {
            if (RedCubes.Count >= 2)
            {
                mainRed = mainRed.prevCube;
                //mainRed = RedCubes[RedCubes.IndexOf(mainRed) - 1];
                //if (secondaryRed != null && RedCubes.Count != 2) secondaryRed = RedCubes[RedCubes.IndexOf(mainRed) - 1];
            }
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
        Debug.Log("Phase Completion Timer Started");
        Invoke("ReportPhaseCompletion", 2f);
    }

    private void ReportPhaseCompletion()
    {
        Level.GetInstance().CheckPhase();
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
    }
}
