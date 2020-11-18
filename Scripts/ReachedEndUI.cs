using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachedEndUI : MonoBehaviour
{
    public GameObject ReachedEnd;
    public void Continue()
    {
        ReachedEnd.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
