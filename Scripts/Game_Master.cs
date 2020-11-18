using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Master : MonoBehaviour
{
    [SerializeField]
    public static Game_Master GM;
    private float timeLeft = 120;
    public int PlayerScore;
    public GameObject PlayerScoreUI;
    private static int maxLives = 3;
    private static int _remainingLives;
    public static int RemainingLives 
    {
        get { return _remainingLives; }
    }

    private void Start() {
        if(GM == null)
        {
            GM = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        }

        _remainingLives = maxLives;
    }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Update() {
         PlayerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + PlayerScore);
    }

   

    public void CountScore (int keyPoints){
        PlayerScore += keyPoints ;
        Debug.Log(PlayerScore);
    }

    public void CountEnemyScore (int enemyPoints){
        PlayerScore += enemyPoints ;
        Debug.Log(PlayerScore);
    }

    public void CountTotalScore (){
        PlayerScore = PlayerScore + (int) (timeLeft * 10);
        Debug.Log(PlayerScore);
    }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    

    public Transform playerPrefab;
    public Transform spawnPoint;
    public  int spwanDelay = 2;
    public GameObject gameOverUI;
    [SerializeField]
    public void EndGame()
    {
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);

    }

    public IEnumerator RespawnPlayer()
    {
        //TODO : ADD A Respwan SOUND 
        yield return new WaitForSeconds(spwanDelay);
        Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
        
    }
    public static void KillPlayer (Health health)
    {
        Destroy(health.gameObject);
        _remainingLives -= 1;
        if( _remainingLives <= 0)
        {
            GM.EndGame();
        }else
        {
            GM.StartCoroutine (GM.RespawnPlayer());
        }
       
    }
}
