using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource clack, victory;

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
    
}
