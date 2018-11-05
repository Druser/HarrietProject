using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {



    public GameObject GameManager;
    int life;
    public bool lost;
    Rigidbody2D RB;

	// Use this for initialization
	void Start ()
    {
        life = Random.Range(1, 15);

        if(transform.position.x < 0)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
        }




    }
	
	// Update is called once per frame
	void Update ()
    {
        //GetComponentInChildren<GameObject>().GetComponent<TextMesh>().text = 
        transform.GetChild(0).GetComponent<TextMesh>().text = life.ToString();

        if (life == 0 || life < 0)
        {
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


}
