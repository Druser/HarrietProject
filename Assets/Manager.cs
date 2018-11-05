using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public GameObject ballInstance;
    public Transform[] spawnPoints;
    int score;
    public Text Score;


    // Use this for initialization
    void Start ()
    {
        score = 0;
        Score.text = "Score:" + score.ToString();
        InvokeRepeating("SpawnBalls", 1, 2);
    } 
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void SpawnBalls()
{
    
      int Index = Random.Range(0, spawnPoints.Length);
      Instantiate(ballInstance, spawnPoints[Index].position, spawnPoints[Index].rotation);
    
}

    public void IncreaseScore(int increment)
    {
        score = score + increment;
        Score.text = "Score:" + score.ToString();
        Debug.Log("Porco dio");
    }

  
}
