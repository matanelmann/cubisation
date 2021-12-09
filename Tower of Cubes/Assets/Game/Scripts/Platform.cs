using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    static Vector3 nextPosition;
    static Vector3 nextScale;
    private static bool moveToNextPosition = false;
    static Transform pt;

    public static void CreatePlatform()
    {
        pt = Instantiate(GameAssets.GetInstance().platform, GameSettings.GameTransform);
        pt.position = new Vector3(GameSettings.LEFT_EDGE, GameSettings.GROUND_Y + (GameSettings.TOWER_HEIGHT - 1) * GameSettings.CUBE_LENGTH);
        pt.localScale = new Vector3(1 + (GameSettings.TOWER_X - GameSettings.LEFT_EDGE - GameSettings.PLATFORM_LENGTH) / GameSettings.PLATFORM_LENGTH, 1);
    }

    public static float getPlatformY()
    {
        return pt.position.y;
    }

    public static void MovePlatform()
    {
        moveToNextPosition = true;
    }

    void Start()
    {
        nextPosition = new Vector3(GameSettings.LEFT_EDGE, GameSettings.GROUND_Y + (GameSettings.TOWER_HEIGHT - 2) * GameSettings.CUBE_LENGTH);
    }

    void Update()
    {
        if (moveToNextPosition && GameHandler.Play)
        {
            if (pt.position.Equals(nextPosition)) // Platform finished moving to the next position
            {
                setNextPlatformPosition();
                moveToNextPosition = false;
                PlayerCube.CreatePlayerCube(); // Spawn a new PlayerCube
            }
            else // Continue moving the platform
            {
                pt.position = Vector3.MoveTowards(pt.position, nextPosition, GameSettings.PLATFORM_MOVING_SPEED * Time.deltaTime);
            }
        }
    }

    private static void setNextPlatformPosition()
    {
        nextPosition = new Vector3(GameSettings.LEFT_EDGE, GameSettings.GROUND_Y + (Tower.cubesList.Count - 2) * GameSettings.CUBE_LENGTH);
    }
}
