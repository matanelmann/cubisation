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
        pt.position = new Vector3(GameConfig.LEFT_EDGE, towerHeight - cc.GetMainRed().length);
        //pt.localScale = new Vector3(1 + (cc.GetMainRed().cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
        pt.localScale = new Vector3(1 + (cc.GetSecondToLast(Cube.Type.Red).cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
    }

    public void SetNext(CubesController cc)
    {
        nextPosition -= new Vector3(0, cc.GetMainRed().length);
        nextScale = new Vector3(1 + (cc.GetSecondToLast(Cube.Type.Red).cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
    }



    /*

    public void MovePlatform()
    {
        setNextPlatformPosition();
        moveToNextPosition = true;
    }

    void Update()
    {
        if (moveToNextPosition && GameHandler.Instance.isGameActive())
        {
            if (pt.position.Equals(nextPosition)) // Platform finished moving to the next position
            {
                moveToNextPosition = false;
                Level.GetInstance().SpawnNewPlayer(); // Spawn a new PlayerCube
            }
            else // Continue moving the platform
            {
                if (nextPosition.Equals(Vector3.zero))
                {
                    setNextPlatformPosition();
                }
                pt.position = Vector3.MoveTowards(pt.position, nextPosition, GameConfig.PLATFORM_MOVING_SPEED * Time.deltaTime);
                pt.localScale = Vector3.MoveTowards(pt.localScale, nextScale, (GameConfig.PLATFORM_MOVING_SPEED / 50) * Time.deltaTime);
            }
        }
    }
    }*/
}
