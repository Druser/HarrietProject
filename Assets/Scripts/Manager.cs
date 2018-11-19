using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    BallScript ballScript;
    public GameObject ballInstance;
    public Transform[] spawnPoints;
    int score, lifeStartInit, sizeInit;
    public int whichCannon;
    public Text Score;

    

    // Use this for initialization
    void Start ()
    {
        score = 0;
        Score.text = "Score:" + score.ToString();
        InvokeRepeating("SpawnBalls", 1, 1);
        whichCannon = Random.Range(1, 7);

    } 
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void SpawnBalls()
    {
        int Index = Random.Range(0, spawnPoints.Length);
        lifeStartInit = Random.Range(1, 161);
        sizeInit = Random.Range(1, 7);
        GameObject newBall = Instantiate(ballInstance, spawnPoints[Index].position, spawnPoints[Index].rotation) as GameObject;
        newBall.GetComponent<BallScript>().InitBall(lifeStartInit, sizeInit);
    }

    public void IncreaseScore(int increment)
    {          
        score = score + increment;
        Score.text = "Score:" + score.ToString();
        Debug.Log("Porco dio");
    }

  
}
