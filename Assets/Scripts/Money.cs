﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    int numberCoins, moneyRand, movementRand, coinValue;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        print(moneyRand);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.FindWithTag("Manager").GetComponent<Manager>().IncreaseMoney(coinValue);
            print(coinValue);
            Destroy(gameObject);
        }
    }

    public void InitCoin(int moneyRandInit)
    {
        this.moneyRand = moneyRandInit;
        CreateOriginalCoin();

    }

    void CreateOriginalCoin()
    {
        movementRand = Random.Range(1, 3);
        if (movementRand == 1)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
        }

        if (moneyRand <= 45)
        {
            coinValue = 1;
        }
        else if (moneyRand >= 46 && moneyRand <= 75)
        {
            coinValue = 5;
        }
        else if (moneyRand >= 76 && moneyRand <= 95)
        {
            coinValue = 10;
        } else  if (moneyRand >= 96 && moneyRand <= 100)
        {
            coinValue = 50;
        }
    }
}
