using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    private static GameAssets instance;
    public Transform redCube;
    public Transform blueCube;
    public Transform platform;
    public Transform arrow;

    public static GameAssets GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
}