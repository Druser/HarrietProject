using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {



    public GameObject GameManager;
    int life, size, lifeStart;
    public bool lost;
    Rigidbody2D RB;
    
	// Use this for initialization
	void Start ()
    {   

          

    }
	
	// Update is called once per frame
	void Update ()
    {
        //GetComponentInChildren<GameObject>().GetComponent<TextMesh>().text = 
        transform.GetChild(0).GetComponent<TextMesh>().text = life.ToString();

        if (life == 0 || life < 0)
        {
            

            if (size > 2)
            {
               // if (size < 5 && size > 2) Start(true, 3, life/2);
               // if (size > 5) Start(true, 3, life/2);

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

    void CreateOriginal()
    {
        lifeStart = Random.Range(1, 30);
        life = lifeStart;
        size = Random.Range(1, 7);


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

        if (transform.position.x < 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }
        GetComponent<Rigidbody2D>().angularVelocity = 100;
    }

}
