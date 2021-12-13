using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    static Vector3 nextPosition = Vector3.zero;
    static Vector3 nextScale;
    private static bool moveToNextPosition = false;
    static Transform pt;

    public static void CreatePlatform()
    {
        pt = Instantiate(GameAssets.GetInstance().platform, GameSettings.GameTransform);
        pt.position = new Vector3(GameSettings.LEFT_EDGE, Tower.GetTowerHeight() - Tower.getTopCube()[0].length);
        pt.localScale = new Vector3(1 + (Tower.getTopCube()[1].cubeTransform.position.x - GameSettings.LEFT_EDGE - GameSettings.PLATFORM_LENGTH) / GameSettings.PLATFORM_LENGTH, 1);
    }

    public static float getPlatformY()
    {
        return pt.position.y;
    }

    public static void MovePlatform()
    {
        setNextPlatformPosition();
        moveToNextPosition = true;
    }

    void Update()
    {
        if (moveToNextPosition && GameHandler.Play)
        {
            if (pt.position.Equals(nextPosition)) // Platform finished moving to the next position
            {
                moveToNextPosition = false;
                PlayerCube.CreatePlayerCube(); // Spawn a new PlayerCube
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

    public static void setNextPlatformPosition()
    {
        if (Tower.TowerEmpty())
        {
            nextPosition = new Vector3(GameSettings.LEFT_EDGE, GameSettings.BOTTOM_EDGE);
        }
        else
        {
            nextPosition = new Vector3(GameSettings.LEFT_EDGE, pt.position.y - Tower.getTopCube()[0].length);
            nextScale = new Vector3(1 + (Tower.getTopCube()[1].cubeTransform.position.x - GameSettings.LEFT_EDGE - GameSettings.PLATFORM_LENGTH) / GameSettings.PLATFORM_LENGTH, 1);
        }
    }

    public static void DestroyPlatform()
    {
        Destroy(pt.gameObject);
    }
}
