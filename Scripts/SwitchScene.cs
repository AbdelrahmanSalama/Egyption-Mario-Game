using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject ReachedEndUI;

    void OnTriggerEnter2D(Collider2D other) {

        ReachedEndUI.SetActive(true);
        
    }
}
