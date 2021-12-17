using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    [HideInInspector] public static List<CubeClass.Cube> BlueCubesList;
     public Transform playerCube;
    public Rigidbody2D cubeRb;
    private Vector3 dragStartPos;
    private Vector3 dragEndPos;
    public static PlayerCube instance;
    private void Awake()
    {
        instance = this;
    }

    public void init()
    {
          BlueCubesList = new List<CubeClass.Cube>();
    }
    public void CreatePlayerCube()
    {
        playerCube = Instantiate(GameAssets.instance.blueCube, GameSettings.GameTransform);
        playerCube.position = new Vector3(GameSettings.LEFT_EDGE / 2f, Platform.instance.getPlatformY() + GameSettings.CUBE_LENGTH / 2);
        playerCube.localScale = Tower.instance.getTopCubes()[0].cubeTransform.localScale;
        cubeRb = playerCube.GetComponent<Rigidbody2D>();
        cubeRb.gravityScale = GameSettings.CUBE_GRAVITY;
        cubeRb.mass = GameSettings.CUBE_MASS;
        CubeClass.Cube newCube = new CubeClass.Cube(playerCube);
        playerCube.gameObject.GetComponent<PlayerInstance>().cube = newCube;
        BlueCubesList.Add(newCube);
    }
    public void CheckInput()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 1);
        if (Input.GetMouseButtonDown(0) && MouseOverCube())
        {
            dragStartPos = mousePos;
        }

        if (Input.GetMouseButton(0))
        {
            TrajectoryLine.instance.RenderLine(dragStartPos, mousePos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragEndPos = mousePos;
            float dragLength = dragStartPos.x - dragEndPos.x;
            if (dragLength > (GameSettings.CUBE_LENGTH / 4)) // Prevent pushing the cube to the left
            {
                PushCube(dragLength);
            }
            TrajectoryLine.instance.EndLine();
        }
    }
    private void PushCube(float dragLength)
    {
        cubeRb.AddForce(Vector2.right * GameSettings.CUBE_FORCE * dragLength);
    }

    private bool MouseOverCube()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mousePos.x, mouseY = mousePos.y;
        if ((mouseX >= playerCube.position.x && mouseX <= playerCube.position.x + GameSettings.CUBE_LENGTH) && (mouseY >= playerCube.position.y && mouseY <= playerCube.position.y + GameSettings.CUBE_LENGTH))
        {
            return true;
        }
        return false;
    }

    public void DestroyPlayer()
    {
        Destroy(playerCube.gameObject);
    }
}
