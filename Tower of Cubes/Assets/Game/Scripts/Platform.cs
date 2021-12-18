using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Vector3 nextPosition = Vector3.zero;
    Vector3 nextScale;
    private bool moveToNextPosition = false;
    Transform pt;
    public static Platform Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void CreatePlatform()
    {
        pt = Instantiate(GameAssets.instance.platform, GameConfig.GameTransform);
        pt.position = new Vector3(GameConfig.LEFT_EDGE, Level.GetInstance().GetTowerHeight() - CubesController.GetInstance().GetLast(Cube.Type.Red).length);
        pt.localScale = new Vector3(1 + (CubesController.GetInstance().GetSecondToLast(Cube.Type.Red).cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
    }

    public float getPlatformY()
    {
        return pt.position.y;
    }

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

    public void setNextPlatformPosition()
    {
        if (Level.GetInstance().TowerEmpty())
        {
            nextPosition = new Vector3(GameConfig.LEFT_EDGE, GameConfig.BOTTOM_EDGE);
        }
        else
        {
            nextPosition = new Vector3(GameConfig.LEFT_EDGE, pt.position.y - CubesController.GetInstance().GetLast(Cube.Type.Red).length);
            nextScale = new Vector3(1 + (CubesController.GetInstance().GetSecondToLast(Cube.Type.Red).cubeTransform.position.x - GameConfig.LEFT_EDGE - GameConfig.PLATFORM_LENGTH) / GameConfig.PLATFORM_LENGTH, 1);
        }
    }

    public void Destroy()
    {
        moveToNextPosition = false;
        Destroy(pt.gameObject);
    }
}
