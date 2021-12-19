using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    
   public void passToNextLevel() {
       GameHandler.Instance.StartGame();
       this.GetComponent<CanvasGroup>().alpha = 0;
       this.GetComponent<CanvasGroup>().interactable = false; //may need to reset to true when game hndller detecs passlevel
   }

   public void returnTomMainMenu() {
       MainMenu.Display();
       this.GetComponent<CanvasGroup>().alpha = 0;
       this.GetComponent<CanvasGroup>().interactable = false;
   }
}

// GameHandler.Instance.Level + 1