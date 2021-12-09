using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static Transform GameTransform;
    public static float RIGHT_EDGE;
    public static float LEFT_EDGE;
    public static float TOP_EDGE;
    public static float BOTTOM_EDGE;
    public static float TOWER_X;
    public static float TOWER_ROOT_Y;
    public static int TOWER_HEIGHT = 2;
    public static float CUBE_SCALE = 1.5f;
    public static float CUBE_LENGTH = 5.12f * CUBE_SCALE;
    public static float CUBE_FORCE = 400f;
    public static float CUBE_GRAVITY = 4f;
    public static float CUBE_MASS = 1.5f;
    public static float PLATFORM_LENGTH = 39.135f;
    public static float PLATFORM_HEIGHT = 3.2f;
    public static float PLATFORM_MOVING_SPEED = 10f;
    public static float GROUND_Y = -45.1f;

    private void Start()
    {
        GameTransform = GameObject.Find("Game").transform;
        float camSize = Camera.main.orthographicSize;
        RIGHT_EDGE = camSize / (16.0f / 9.0f);
        LEFT_EDGE = -1 * RIGHT_EDGE;
        TOP_EDGE = camSize;
        BOTTOM_EDGE = -1 * camSize;

        TOWER_X = RIGHT_EDGE * 0.5f;
        TOWER_ROOT_Y = BOTTOM_EDGE + CUBE_LENGTH * CUBE_SCALE * 1.5f;
    }
}