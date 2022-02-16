using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    public static LineRenderer lr;
    public static Gradient[] gradientsStat;
    public Gradient[] gradients;
    private void Awake()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        gradientsStat = gradients;
    }
    public static void RenderLine(Vector3 startPoint, Vector3 endPoint, Cube mainBlue)
    {
        if (CrossSceneInfo.ChosenLevel <= 1)
        {
            lr.colorGradient = gradientsStat[1];
        }
        else if (CrossSceneInfo.ChosenLevel == 4)
        {
            lr.colorGradient = gradientsStat[2];
        }
        else
        {
            lr.colorGradient = gradientsStat[0];
        }

        lr.widthCurve = new AnimationCurve(new Keyframe(0.1f, mainBlue.scale), new Keyframe(0.2f, 0.0f));
        lr.widthMultiplier = 5.12f;
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