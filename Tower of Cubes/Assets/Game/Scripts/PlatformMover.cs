using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private Level level;
    private Platform platform;

    public void GetReferences(Level level, Platform platform)
    {
        this.level = level;
        this.platform = platform;
    }
    void Update()
    {
        if (platform != null && GameHandler.GetInstance().isGameActive())
        {
            if (level.ST.MESSY == 0)
            {
                if (platform.pt.position != platform.nextPosition || platform.pt.localScale != platform.nextScale)
                {
                    platform.pt.position = Vector3.MoveTowards(platform.pt.position, platform.nextPosition, GameConfig.PLATFORM_MOVING_SPEED * Time.deltaTime);
                    platform.pt.localScale = Vector3.MoveTowards(platform.pt.localScale, platform.nextScale, (GameConfig.PLATFORM_MOVING_SPEED / 50) * Time.deltaTime);
                }
                else
                {
                    level.FinishPlatformMovement();
                }
            }
            else
            {
                if (platform.pt.localScale.x >= platform.nextScale.x)
                {
                    if (platform.pt.localScale != platform.nextScale)
                    {
                        platform.pt.localScale = Vector3.MoveTowards(platform.pt.localScale, platform.nextScale, (GameConfig.PLATFORM_MOVING_SPEED / 50) * Time.deltaTime);
                    }
                    else if (platform.pt.position != platform.nextPosition)
                    {
                        platform.pt.position = Vector3.MoveTowards(platform.pt.position, platform.nextPosition, GameConfig.PLATFORM_MOVING_SPEED * Time.deltaTime);
                    }
                    else
                    {
                        level.FinishPlatformMovement();
                    }
                }
                else
                {
                    if (platform.pt.position != platform.nextPosition)
                    {
                        platform.pt.position = Vector3.MoveTowards(platform.pt.position, platform.nextPosition, GameConfig.PLATFORM_MOVING_SPEED * Time.deltaTime);
                    }
                    else if (platform.pt.localScale != platform.nextScale)
                    {
                        platform.pt.localScale = Vector3.MoveTowards(platform.pt.localScale, platform.nextScale, (GameConfig.PLATFORM_MOVING_SPEED / 50) * Time.deltaTime);
                    }
                    else
                    {
                        level.FinishPlatformMovement();
                    }
                }
            }
        }
    }
}