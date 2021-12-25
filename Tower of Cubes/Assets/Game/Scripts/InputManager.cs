using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    private bool dragging;
    private Vector3 dragStartPos;
    private Vector3 dragEndPos;
    private Vector3 mousePos;
    private Vector3 cubeSide;
    public void Check()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 1);
        Cube mainBlue = CubesController.GetInstance().GetMainBlue();
        cubeSide = mainBlue.cubeTransform.position + new Vector3(0, mainBlue.length / 2);
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = mousePos;
            dragging = true;
        }
        if (dragging && Input.GetMouseButton(0))
        {
            TrajectoryLine.RenderLine(cubeSide, cubeSide - new Vector3(dragStartPos.x - mousePos.x, 0));
        }
        if (dragging && Input.GetMouseButtonUp(0))
        {
            dragging = false;
            dragEndPos = mousePos;
            float dragLength = dragStartPos.x - dragEndPos.x;
            if (dragLength > (mainBlue.length / 4)) // Prevent pushing the cube to the left
            {
                mainBlue.Push(dragLength);
            }
            TrajectoryLine.EndLine();
        }
    }
}
