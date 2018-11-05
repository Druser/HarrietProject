using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    int score;
    public GameObject ballInstance;
    public Transform[] spawnPoints;



    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("SpawnBalls", 1, 1);
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
}
