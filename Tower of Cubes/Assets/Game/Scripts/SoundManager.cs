using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource clack, victory, buttonTap, levelBackground;

    private void Awake()
    {
        instance = this;
    }

    public static SoundManager GetInstance()
    {
        return instance;
    }
    
    public void Clack()
    {
        clack.Play();
    }

    public void LevelPassed()
    {
        victory.Play();
    }

    public void ButtonTap()
    {
        buttonTap.Play();
    }

    public void PlayLevelBackground()
    {
        levelBackground.Play();
    }
    
}
