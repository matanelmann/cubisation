using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    Transform playerCube;
    Rigidbody2D cubeRb;
    private bool dragging = false;
    private float dragStartPos;
    private float dragEndPos;
    
    void Start()
    {
        CreatePlayerCube();
    }

    private void Update()
    {
        CheckInput();
    }
    private void CreatePlayerCube()
    {
        playerCube = Instantiate(GameAssets.GetInstance().blueCube, transform.parent);
        playerCube.position = new Vector3(GameSettings.LEFT_EDGE / 2, GameSettings.TOWER_ROOT_Y);
        playerCube.localScale = new Vector3(GameSettings.CUBE_SCALE, GameSettings.CUBE_SCALE, GameSettings.CUBE_SCALE);
        cubeRb = playerCube.GetComponent<Rigidbody2D>();
        cubeRb.gravityScale = GameSettings.CUBE_GRAVITY;
    }
    private void CheckInput()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && MouseOverCube())
        {
            dragStartPos = mousePos.x;
            dragging = true;
        }
        if (Input.GetMouseButtonUp(0))
        { 
            dragEndPos = mousePos.x;
            dragging = false;
            float dragLength = dragStartPos - dragEndPos;
            if (dragLength > (GameSettings.CUBE_LENGTH / 4)) // Prevent pushing the cube to the left
            {
                PushCube(dragLength);
            }
        }
        /*if (dragging && (dragStartPos - mousePos.x >= cubeLength / 4))
        {

        }*/
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
