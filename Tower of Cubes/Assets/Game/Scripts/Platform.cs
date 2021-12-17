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
        pt = Instantiate(GameAssets.instance.platform, GameSettings.GameTransform);
        pt.position = new Vector3(GameSettings.LEFT_EDGE, Tower.Instance.GetTowerHeight() - Tower.Instance.getTopCubes()[0].length);
        pt.localScale = new Vector3(1 + (Tower.Instance.getTopCubes()[1].cubeTransform.position.x - GameSettings.LEFT_EDGE - GameSettings.PLATFORM_LENGTH) / GameSettings.PLATFORM_LENGTH, 1);
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
                PlayerCube.Instance.CreatePlayerCube(); // Spawn a new PlayerCube
            }
            else // Continue moving the platform
            {
                if (nextPosition.Equals(Vector3.zero))
                {
                    setNextPlatformPosition();
                }
                pt.position = Vector3.MoveTowards(pt.position, nextPosition, GameSettings.PLATFORM_MOVING_SPEED * Time.deltaTime);
                pt.localScale = Vector3.MoveTowards(pt.localScale, nextScale, (GameSettings.PLATFORM_MOVING_SPEED / 50) * Time.deltaTime);
            }
        }
    }

    public void setNextPlatformPosition()
    {
        if (Tower.Instance.TowerEmpty())
        {
            nextPosition = new Vector3(GameSettings.LEFT_EDGE, GameSettings.BOTTOM_EDGE);
        }
        else
        {
            nextPosition = new Vector3(GameSettings.LEFT_EDGE, pt.position.y - Tower.Instance.getTopCubes()[0].length);
            nextScale = new Vector3(1 + (Tower.Instance.getTopCubes()[1].cubeTransform.position.x - GameSettings.LEFT_EDGE - GameSettings.PLATFORM_LENGTH) / GameSettings.PLATFORM_LENGTH, 1);
        }
    }

    public void DestroyPlatform()
    {
        Destroy(pt.gameObject);
    }
}
