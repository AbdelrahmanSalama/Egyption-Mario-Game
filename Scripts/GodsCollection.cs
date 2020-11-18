using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsCollection : MonoBehaviour
{
    public GameObject GodInfoUI;
    
     void OnTriggerEnter2D(Collider2D col)
       {

            if (col.gameObject.tag.Equals ("Player"))
            {
            
                 Destroy (gameObject);  
                 GodInfoUI.SetActive(true);
            
            }
        }
    

}
