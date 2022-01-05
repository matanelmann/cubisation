using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{

    public static UnlockLevel instance;
    private Level level;
    private int completedLevels;

    private void Awake()
    {
        instance = this;
        completedLevels = PlayerPrefs.GetInt("level", 0);
    }
    public static UnlockLevel getInstance() 
    {
        return instance;
    }

    public int getCompletedLevels() 
    {
        return completedLevels;
    }
    // void Start()
    // {
    //     completedLevels = PlayerPrefs.GetInt("level", 0);
    // }

    public void unlockLevel(int levelNum)
    {
        if(completedLevels < levelNum) 
        {
            PlayerPrefs.SetInt("level", level.LevelNum);
            completedLevels = PlayerPrefs.GetInt("level");
        }
       
    }
  
}
