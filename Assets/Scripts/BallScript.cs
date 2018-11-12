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
    
    
	// Use this for initialization
	void Start ()
    {
 
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Rigidbody2D>().angularVelocity = 100;
        //GetComponentInChildren<GameObject>().GetComponent<TextMesh>().text = 
        transform.GetChild(0).GetComponent<TextMesh>().text = life.ToString();

        if (Input.GetKeyDown("n"))
        {
            life--;
        }
        if (life == 0 || life < 0)
        {



            if (size <= 5 && size > 2)
            {
                lifeStart = lifeStart / 2;
                size = 2;
                GameObject newBall = Instantiate(Ball, transform.position, transform.rotation) as GameObject;
                newBall.GetComponent<BallScript>().InitBall(lifeStart, size);
            }
            else if (size > 5)
            {
                lifeStart = lifeStart / 2;
                size = 5;
                GameObject newBall = Instantiate(Ball, transform.position, transform.rotation) as GameObject;
                newBall.GetComponent<BallScript>().InitBall(lifeStart, size);
            }

          

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

    public void CreateOriginal()
    {

        life = lifeStart;
        //Debug.Log(life);


        if (transform.position.x < 0)
        {
            Debug.Log("porco");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log(transform.localPosition.x);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }
        //GetComponent<Rigidbody2D>().angularVelocity = 100;

        if (size == 1 || size == 2)
        {
            GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
        else if (size == 3 || size == 4 || size == 5)
        {
            GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (size == 6)
        {
            GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

    }

}
