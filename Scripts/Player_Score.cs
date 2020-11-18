using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player_Score : MonoBehaviour
{
    private float timeLeft = 120;
    //public int PlayerScore = 0;

    public GameObject timeLeftUI;
   // public GameObject PlayerScoreUI;
    public GameObject LivesUI;

    // Update is called once per frame
    void Update()
    {
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time: " + (int)timeLeft);
       // PlayerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + PlayerScore);
        LivesUI.gameObject.GetComponent<Text>().text = ("Lives: " + Game_Master.RemainingLives.ToString());
        timeLeft-= Time.deltaTime;
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene ("Level1");
        }
    }

    /*void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.name == "End Level Trigger")
            CountScore ();

        if (trig.gameObject.tag == "coin"){
            PlayerScore += 100;
            //Destroy (trig.gameObject);
            
        }    
        
        if (trig.gameObject.tag == "Enemy"){
            PlayerScore += 100;
            
        }
    }

    public void CountScore (){
        PlayerScore = PlayerScore + (int) (timeLeft * 10);
        Debug.Log(PlayerScore);
    }*/


}
