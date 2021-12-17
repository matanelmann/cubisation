using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{

    public static GameAssets instance;
    private void Awake()
    {
        instance = this;
    }
    public Transform redCube;
    public Transform blueCube;
    public Transform platform;
    public Transform arrow;

   
}