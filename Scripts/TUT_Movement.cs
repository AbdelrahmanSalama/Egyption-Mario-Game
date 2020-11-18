using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TUT_Movement : MonoBehaviour
{
   public Animator animator;
   public int PlayerJumpPower = 1250; 
   public int PlayerSpeed = 10 ;
   public bool IsGrounded;
   public bool CanDoubleJump;
   public bool PlayerDead = false;

    public Game_Master GM;
    public int enemyPoints = 100;
   
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRaycast ();
        if(PlayerDead == true){
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }
    }


    void Jump() {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * PlayerJumpPower);
        GetComponent<AudioSource>().Play();
    }



    void PlayerMovement(){

        //Jumping

             if (Input.GetButtonDown ("Jump") )
              {
                  if(IsGrounded)
                  {
                    Jump();
                    CanDoubleJump = true;
                    IsGrounded = false;
                  }
                    else
                    {
                        if(CanDoubleJump)
                        {
                            CanDoubleJump = false;
                            GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x,0);
                            GetComponent<Rigidbody2D>().AddForce (Vector2.up * PlayerJumpPower);
                            GetComponent<AudioSource>().Play();
                        }

                    }
              }

        //Moving_Forward_Back

               
            animator.SetFloat("Horizontal",Input.GetAxis("Horizontal"));
             Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
             transform.position =transform.position + horizontal * Time.deltaTime * PlayerSpeed ;

    }

    void OnCollisionEnter2D(Collision2D col) {
        //Debug.Log("Player collided with " + col.collider.name);
        if(col.gameObject.tag == ("ground"))
        {
            IsGrounded = true;
        }
        if(col.gameObject.tag == ("rock"))
        {
            IsGrounded = true;
        }
        if(col.gameObject.tag == ("break"))
        {
            IsGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D trig) {
        if (trig.gameObject.name == "End Level Trigger")
            GM.CountTotalScore();

    }


    void PlayerRaycast (){

        //Ray_Right

        RaycastHit2D hitRight = Physics2D.Raycast (transform.position,Vector2.right);
        if (hitRight.distance < 1.35 && hitRight.collider.tag == "Enemy"){
            Debug.Log("Killed by Enemy");
            GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 700);
            PlayerDead = true;
            
        }

        //Ray_Down
        RaycastHit2D hitDown = Physics2D.Raycast (transform.position,Vector2.down);
        if (hitDown.distance < 1.35 ){
            if(hitDown.collider.tag == "Enemy"){
                  Debug.Log("Touched Enemy");
                  GM.CountEnemyScore(enemyPoints);
                  Destroy(hitDown.collider.gameObject);
            }
        }
            
    }
}


