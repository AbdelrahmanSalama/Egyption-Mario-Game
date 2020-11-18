using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReg : MonoBehaviour
{
    private GameObject Player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    

     void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float x = Mathf.Clamp (Player.transform.position.x,xMin,xMax);
        float y = Mathf.Clamp (Player.transform.position.y,yMin,yMax);
        gameObject.transform.position= new Vector3 (x,y,gameObject.transform.position.z);

        

    }

   
}
