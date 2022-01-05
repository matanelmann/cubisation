using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;
    private static bool active;

    private void Awake()
    {
        instance = this;
    }

    public static bool GetActive()
    {
        return active;
    }
    //activates the tutorial mode when tutorial button is pressed
    public void ActivateTutorial() 
    {
        active = true;
    }
    //deactivates the tutorial when toturial is complete
    public void DeactivateTutorial() 
    {
        active = false;
    }
}
