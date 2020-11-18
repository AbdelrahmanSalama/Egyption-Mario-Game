using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Collection : MonoBehaviour
{
    public Game_Master GM;
    public int keyPoints = 100;

    void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.tag.Equals ("Player")){
            
            //GetComponent<AudioSource>().Play();
            GM.CountScore(keyPoints);
            Destroy (gameObject);
            
            
        }
    }
}
