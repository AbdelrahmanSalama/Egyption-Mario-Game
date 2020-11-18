using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats{
        public int Health = 100;
    }

    public PlayerStats playerStats = new PlayerStats();


// Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -7 )
        {
            DamagePlayer(99999999);
        }

    }

    public void DamagePlayer (int damage)
    {
        playerStats.Health -= damage;
        if(playerStats.Health <= 0)
        {
    
            Game_Master.KillPlayer(this);
        }
    }
    

   /* void Die() 
    {
        SceneManager.LoadScene("Level1");
    
    }*/
}
