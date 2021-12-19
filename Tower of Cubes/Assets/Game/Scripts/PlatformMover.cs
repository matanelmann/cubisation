using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{  
    private Platform platform;
    
    // Update is called once per frame
    void Update()
    {
        platform = Level.instance.GetPlatformReference();
        platform.pt.position = Vector3.MoveTowards(platform.pt.position, platform.nextPosition ,GameConfig.PLATFORM_MOVING_SPEED * Time.deltaTime);
        platform.pt.localScale = Vector3.MoveTowards(platform.pt.localScale, platform.nextScale, (GameConfig.PLATFORM_MOVING_SPEED / 50) * Time.deltaTime);
    }
    private void fixedUpdate() {
        platform = Level.instance.GetPlatformReference();
        if (platform.pt.position == platform.nextPosition)
        {
            Level.GetInstance().SpawnNewPlayer();
        }

    }

    
}

    // public void MovePlatform()
    // {
    //     setNextPlatformPosition();
    //     moveToNextPosition = true;
    // }

    // void Update()
    // {
    //     if (moveToNextPosition && GameHandler.Instance.isGameActive())
    //     {
    //         if (pt.position.Equals(nextPosition)) // Platform finished moving to the next position
    //         {
    //             moveToNextPosition = false;
    //             Level.GetInstance().SpawnNewPlayer(); // Spawn a new PlayerCube
    //         }
    //         else // Continue moving the platform
    //         {
    //             if (nextPosition.Equals(Vector3.zero))
    //             {
    //                 setNextPlatformPosition();
    //             }
    //             pt.position = Vector3.MoveTowards(pt.position, nextPosition, GameConfig.PLATFORM_MOVING_SPEED * Time.deltaTime);
    //             pt.localScale = Vector3.MoveTowards(pt.localScale, nextScale, (GameConfig.PLATFORM_MOVING_SPEED / 50) * Time.deltaTime);
    //         }
    //     }
    // }