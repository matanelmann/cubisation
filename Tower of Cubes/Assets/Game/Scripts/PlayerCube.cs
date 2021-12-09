using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    public static Transform playerCube;
    static Rigidbody2D cubeRb;
    private float dragStartPos;
    private float dragEndPos;

    private void Update()
    {
        CheckInput();
    }
    public static void CreatePlayerCube()
    {
        playerCube = Instantiate(GameAssets.GetInstance().blueCube, GameSettings.GameTransform);
        playerCube.position = new Vector3(GameSettings.LEFT_EDGE / 1.5f, Platform.getPlatformY() + GameSettings.CUBE_LENGTH / 2);
        playerCube.localScale = new Vector3(GameSettings.CUBE_SCALE, GameSettings.CUBE_SCALE, GameSettings.CUBE_SCALE);
        cubeRb = playerCube.GetComponent<Rigidbody2D>();
        cubeRb.gravityScale = GameSettings.CUBE_GRAVITY;
        cubeRb.mass = GameSettings.CUBE_MASS;
    }
    private void CheckInput()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && MouseOverCube())
        {
            dragStartPos = mousePos.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragEndPos = mousePos.x;
            float dragLength = dragStartPos - dragEndPos;
            if (dragLength > (GameSettings.CUBE_LENGTH / 4)) // Prevent pushing the cube to the left
            {
                PushCube(dragLength);
            }
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
        if ((mouseX >= playerCube.position.x && mouseX <= playerCube.position.x + GameSettings.CUBE_LENGTH) && (mouseY >= playerCube.position.y && mouseY <= playerCube.position.y + GameSettings.CUBE_LENGTH)) { 
            return true;
        }
        return false;
    }
}
