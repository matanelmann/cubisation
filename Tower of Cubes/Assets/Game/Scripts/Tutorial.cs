using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    public static bool isActive;

    private void Awake()
    {
        instance = this;
    }

    public static bool Getactive()
    {
        return isActive;
    }
    //activates the tutorial mode when tutorial button is pressed
    public void activateTutorial() 
    {
        isActive = true;
    }
    //deactivates the tutorial when toturial is complete
    public void deactivateTutorial() 
    {
        isActive = false;
    }
}
