using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public static NextLevel instance;
    private void Awake()
    {
        instance = this;
    }

   public void passToNextLevel() {
       int LevelNum = Level.instance.LevelNum;
       GameHandler.Instance.StartGame();
       this.GetComponent<CanvasGroup>().alpha = 0;
       this.GetComponent<CanvasGroup>().interactable = false; //may need to reset to true when game hndller detecs passlevel
       Level.instance.StartLevel(LevelNum+1);
   }

   public void returnTomMainMenu() {
       MainMenu.Display();
       this.GetComponent<CanvasGroup>().alpha = 0;
       this.GetComponent<CanvasGroup>().interactable = false;
   }
}

