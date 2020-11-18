using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int EnemySpeed;
    public int xDiraction;
    

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xDiraction,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (xDiraction,0) * EnemySpeed;
        if(hit.distance < 1.5f)
        {
            Flip();
        } 
    }

    void Flip()
    {
         SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if(xDiraction > 0)
        {
            xDiraction = -1;
            sr.flipX = true;
        }
        else {
            xDiraction = 1;
            sr.flipX = false;
        }

        
    }
}
