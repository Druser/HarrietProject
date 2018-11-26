using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {



    public GameObject GameManager;
    public GameObject Ball;
    public int life, size, lifeStart,kek;
    public bool lost;
    Rigidbody2D RB;
    public Sprite ballSprite1, ballSprite2, ballSprite3, ballSprite4, ballSprite5, ballSprite6, ballSprite7, ballSprite8;
    Sprite ballSelection;
  

    // Use this for initialization
    void Start ()
    {



    }
	
	// Update is called once per frame
	void Update ()
    {
        //Color of the Ball

        if (life >= 1 && life <= 19)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite1;
        }
        else if (life >= 20 && life <= 39)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite2;
        }
        else if (life >= 40 && life <= 59)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite3;
        }
        else if (life >= 60 && life <= 79)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite4;
        }
        else if (life >= 80 && life <= 99)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite5;
        }
        else if (life >= 100 && life <= 119)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite6;
        }
        else if (life >= 120 && life <= 139)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite7;
        }
        else if (life >= 140 && life <= 160)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite8;
        }
        else if (life >= 1 && life <= 19)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprite1;
        }

        GetComponent<Rigidbody2D>().angularVelocity = 100;
        transform.GetChild(0).GetComponent<TextMesh>().text = life.ToString();

        if (Input.GetKeyDown("n"))
        {
            life = 0;
        }

        //Create a smaller ball when killed, if it's a medium or big ball
        if (life == 0 || life < 0)
        {
            if (size <= 5 && size > 2)
            {
                //Spawn Ball half the Size
                lifeStart = lifeStart / 2;
                size = 2;
                GameObject newBall = Instantiate(Ball, transform.position, transform.rotation) as GameObject;
                newBall.GetComponent<BallScript>().InitBall(lifeStart, size);
                //Spawn 3 Coins
                GameObject.FindWithTag("Manager").GetComponent<Manager>().SpawnCoins(transform);
                GameObject.FindWithTag("Manager").GetComponent<Manager>().SpawnCoins(transform);

            }
            else if (size > 5)
            {
                //Spawn Ball half the Size
                lifeStart = lifeStart / 2;
                size = 5;
                GameObject newBall = Instantiate(Ball, transform.position, transform.rotation) as GameObject;
                newBall.GetComponent<BallScript>().InitBall(lifeStart, size);
                //Spawn 6 Coins
                GameObject.FindWithTag("Manager").GetComponent<Manager>().SpawnCoins(transform);
                GameObject.FindWithTag("Manager").GetComponent<Manager>().SpawnCoins(transform);
                GameObject.FindWithTag("Manager").GetComponent<Manager>().SpawnCoins(transform);
                GameObject.FindWithTag("Manager").GetComponent<Manager>().SpawnCoins(transform);
                GameObject.FindWithTag("Manager").GetComponent<Manager>().SpawnCoins(transform);
            }
            GameObject.FindWithTag("Manager").GetComponent<Manager>().SpawnCoins(transform);
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            life = life - 1;
            GameObject.FindWithTag("Manager").GetComponent<Manager>().IncreaseScore(1);

        }


        if (collision.tag == "Player")
        {

            lost = true;
            Time.timeScale = 0.0f;

        }



    }

    public void InitBall(int lifeStartInit, int sizeInit)
    {
        this.lifeStart = lifeStartInit;
        this.size = sizeInit;
        CreateOriginal();
    }

    //Create Original Ball
    public void CreateOriginal()
    {

        life = lifeStart;
        if (transform.position.x < 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }
        //GetComponent<Rigidbody2D>().angularVelocity = 100;

        if (size == 1 || size == 2)
        {
            GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (size == 3 || size == 4 || size == 5)
        {
            GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
        else if (size == 6)
        {
            GetComponent<Transform>().localScale = new Vector3(0.37f, 0.37f, 0.37f);
        }

    }

}
