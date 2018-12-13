using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    BallScript ballScript;
    public GameObject ballInstance, coinInstance;
    public Transform[] spawnPoints;
    int score, highScore, lifeStartInit, sizeInit, money, moneyAccount, moneyRandInit;
    string username;
    public int whichCannon;
    public Text Score, Money;

    

    // Use this for initialization
    void Start ()
    {
        
        score = 0;
        money = 0;
        Score.text = "Score:" + score.ToString();
        InvokeRepeating("SpawnBalls", 1, 1);
        whichCannon = Random.Range(1, 7);

        PlayerPrefs.GetInt("MoneyAccount", moneyAccount);
        print(moneyAccount);
    } 
	
	// Update is called once per frame
	void Update ()
    {
        Score.text =  score.ToString();
        Money.text =  money.ToString();

        if (score > highScore)
        {
            highScore = score;
        }
    }

    void SpawnBalls()
    {
        int Index = Random.Range(0, spawnPoints.Length);
        lifeStartInit = Random.Range(1, 161);
        sizeInit = Random.Range(1, 7);
        GameObject newBall = Instantiate(ballInstance, spawnPoints[Index].position, spawnPoints[Index].rotation) as GameObject;
        newBall.GetComponent<BallScript>().InitBall(lifeStartInit, sizeInit);
    }

    public void SpawnCoins(Transform coinTrans)
    {
        moneyRandInit = Random.Range(1, 101);
        GameObject newCoin = Instantiate(coinInstance, coinTrans.position, coinTrans.rotation) as GameObject;
        newCoin.GetComponent<Money>().InitCoin(moneyRandInit);

    }

    public void IncreaseScore(int increment)
    {          
        score = score + increment;
    }

    public void IncreaseMoney(int value)
    {
        money = money + value;
    }

    public void Death()
    {
        moneyAccount = moneyAccount + money;
        print(moneyAccount);
        PlayerPrefs.SetInt("MoneyAccount", moneyAccount);

    }


}
