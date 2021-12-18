using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public static Transform GameTransform;
    public static float SCREEN_RATIO = 20f / 9f;
    public static float RIGHT_EDGE;
    public static float LEFT_EDGE;
    public static float TOP_EDGE;
    public static float BOTTOM_EDGE;
    public static float TOWER_X;
    public static float PLATFORM_LENGTH = 39.135f;
    public static float PLATFORM_HEIGHT = 3.2f;
    public static float PLATFORM_MOVING_SPEED = 10f;
    public static float GROUND_Y = -45.1f;

    private void Awake()
    {
        GameTransform = GameObject.Find("Game").transform;
        float camSize = Camera.main.orthographicSize;
        RIGHT_EDGE = camSize / SCREEN_RATIO;
        LEFT_EDGE = -1 * RIGHT_EDGE;
        TOP_EDGE = camSize;
        BOTTOM_EDGE = -1 * camSize;
        TOWER_X = RIGHT_EDGE * 0.6f;
    }
}
