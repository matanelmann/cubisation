using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    public static Transform playerCube;
    public static Rigidbody2D cubeRb;
    private static Vector3 dragStartPos;
    private static Vector3 dragEndPos;
    public static GameObject[] popups;
    public static int popupIndex;

    public static void CreatePlayerCube()
    {
        playerCube = Instantiate(GameAssets.GetInstance().blueCube, GameSettings.GameTransform);
        playerCube.position = new Vector3(GameSettings.LEFT_EDGE / 1.5f, Platform.getPlatformY() + GameSettings.CUBE_LENGTH / 2);
        playerCube.localScale = Tower.getTopCube()[0].cubeTransform.localScale;
        cubeRb = playerCube.GetComponent<Rigidbody2D>();
        cubeRb.gravityScale = GameSettings.CUBE_GRAVITY;
        cubeRb.mass = GameSettings.CUBE_MASS;
    }
    public static void CheckInput()
    {
        for (int i = 0; i < popups.Length; i++)
        {
            if (i == popupIndex) {
                popups[popupIndex].SetActive(true);
            } else {
                popups[popupIndex].SetActive(false);
            }
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 1);
        if (popupIndex == 0) {
            if (Input.GetMouseButtonDown(0) && MouseOverCube())
            {
                dragStartPos = mousePos;
            }

            if (Input.GetMouseButton(0))
            {
                TrajectoryLine.RenderLine(dragStartPos, mousePos);
            }

            if (Input.GetMouseButtonUp(0))
            {
                dragEndPos = mousePos;
                float dragLength = dragStartPos.x - dragEndPos.x;
                if (dragLength > (GameSettings.CUBE_LENGTH / 4)) // Prevent pushing the cube to the left
                {
                    PushCube(dragLength);
                }
                TrajectoryLine.EndLine();
            }
        }
    }
    private static void PushCube(float dragLength)
    {
        cubeRb.AddForce(Vector2.right * GameSettings.CUBE_FORCE * dragLength);
    }

    private static bool MouseOverCube()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mousePos.x, mouseY = mousePos.y;
        if ((mouseX >= playerCube.position.x && mouseX <= playerCube.position.x + GameSettings.CUBE_LENGTH) && (mouseY >= playerCube.position.y && mouseY <= playerCube.position.y + GameSettings.CUBE_LENGTH)) { 
            return true;
        }
        return false;
    }

  public static void DestroyPlayer()
    {
        Destroy(playerCube.gameObject);
    }
}
