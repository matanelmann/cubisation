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
    public void Check()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 1);
        Cube mainBlue = CubesController.GetInstance().GetMainBlue();
        if (Input.GetMouseButtonDown(0) && mainBlue.MouseOver)
        {
            dragStartPos = mousePos;
            dragging = true;
        }
        if (dragging && Input.GetMouseButton(0))
        {
            TrajectoryLine.RenderLine(dragStartPos, mousePos);
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
