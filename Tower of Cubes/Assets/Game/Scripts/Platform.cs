using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform
{
    public Vector3 nextPosition, nextScale;
    public Transform pt;
    

    public Platform(Transform pt, CubesController cc, float towerHeight)
    {
        this.pt = pt;
        setInitial(cc, towerHeight);
        SetNext(cc);
    }

    private void setInitial(CubesController cc, float towerHeight)
    {
        if (cc.RedCubes.Count < 2)
        {
            pt.position = new Vector3(GameConfig.LEFT_EDGE, GameConfig.GROUND_Y - 10f);
            pt.localScale = new Vector3(1 + (cc.GetMainRed().cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
        }
        else
        {
            pt.position = new Vector3(GameConfig.LEFT_EDGE, towerHeight - cc.GetMainRed().length);
            pt.localScale = new Vector3(1 + (cc.GetSecondToLast(Cube.Type.Red).cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
        }
    }

    public void SetNext(CubesController cc)
    {
        if (cc.RedCubes.Count < 2)
        {
            nextPosition = new Vector3(GameConfig.LEFT_EDGE, GameConfig.GROUND_Y - GameConfig.PLATFORM_HEIGHT);
            nextScale = new Vector3(1 + (cc.GetMainRed().cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
        }
        else
        {
            nextPosition = pt.position - new Vector3(0, cc.GetMainRed().length);
            nextScale = new Vector3(1 + (cc.GetSecondToLast(Cube.Type.Red).cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
        }
    }
}
