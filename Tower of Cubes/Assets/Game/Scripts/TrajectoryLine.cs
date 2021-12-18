using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    public static LineRenderer lr;
    private void Awake()
    {
        lr = GameConfig.GameTransform.GetComponent<LineRenderer>();
    }
    public static void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        endPoint.y = startPoint.y;
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;
        lr.SetPositions(points);
    }
    public static void EndLine()
    {
        lr.positionCount = 0;
    }
}