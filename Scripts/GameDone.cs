using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDone : MonoBehaviour
{
    public GameObject ReachedEndGame;

   public void Quit()
   {
      Debug.Log("Application Quit!");
      Application.Quit();
   }

   public void Retry()
   {
       ReachedEndGame.SetActive(false);
       SceneManager.LoadScene(1);
   }
}
