using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour

{
    //list of cubes- can take the tranform og the cuurnt cube. by len
    //Y- like the cube
    //offset scale x- (x cube - left edge of the screen -platform len)/pltforn len 
    // Start is called before the first frame update
    //attch
    //isnt it a proble the Cube and List are private?

    [HideInInspector] public Tower _tower;
    private static int i = 1; // i will remain as in the last call of the function
    private static int j = 0; // j will remain as in the last call of the function
    private static float CUBE_X_POS;

    void Start()
    {
        _tower = FindObjectOfType<Tower>();
        CreatePlatfore();
    }

    // Update is called once per frame
    void Update()
    {
        //to be filled 
    }

    private void CreatePlatfore()
    {
        Transform platformTransform = Instantiate(GameAssets.GetInstance().platform, transform.parent);
        platformTransform.position = new Vector3(PlatformXPosition(), PlatformYPosition());
        i += 1;
        j += 1;
        //this.transform.localScale = new Vector3(13, -16, 0);
    }

    //Calculates the Y posion for the platform by the current cubes Y possion. 

    private float PlatformYPosition()
    {
        
        return (_tower.GetTowerLength() - i)* GameSettings.CUBE_LENGTH - 50f;
        
    }

    private float PlatformXPosition()
    {
        CUBE_X_POS = _tower.cubesList[_tower.GetTowerLength() - i].getTransform().position.x;

        return (CUBE_X_POS - GameSettings.LEFT_EDGE - GameSettings.PLATFORM_LENGTH) / (GameSettings.PLATFORM_LENGTH -28.2f);
    }
}