using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Sprite BulletSprite1, BulletSprite2, BulletSprite3, BulletSprite4, BulletSprite5, BulletSprite6;
    int bulletSelection;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Select the Bullet Sprite
        bulletSelection = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().whichCannon;

        if (bulletSelection == 1)
        {
            GetComponent<SpriteRenderer>().sprite = BulletSprite1;
        }
        else if (bulletSelection == 2)
        {
            GetComponent<SpriteRenderer>().sprite = BulletSprite2;
        }
        else if (bulletSelection == 3)
        {
            GetComponent<SpriteRenderer>().sprite = BulletSprite3;
        }
        else if (bulletSelection == 4)
        {
            GetComponent<SpriteRenderer>().sprite = BulletSprite4;
        }
        else if (bulletSelection == 5)
        {
            GetComponent<SpriteRenderer>().sprite = BulletSprite5;
        }
        else if (bulletSelection == 6)
        {
            GetComponent<SpriteRenderer>().sprite = BulletSprite6;
        }

        //Move the Bullet Up
        transform.Translate(Vector3.up * (Time.deltaTime * 10), Space.World);

        //Destruction when the Bullet goes beyond the screen
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            Destroy(gameObject);

        }
    }


}
