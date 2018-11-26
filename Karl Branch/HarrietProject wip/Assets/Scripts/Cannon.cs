using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    
    public Vector3 fingerposition;
    public GameObject bulletInstance;
    public int bulletSpeed;
    int frames = 0, cannonSelection;
    public Sprite CannonSprite1, CannonSprite2, CannonSprite3, CannonSprite4, CannonSprite5, CannonSprite6;


    // Use this for initialization
    void Start()
    {
        Input.multiTouchEnabled = false;
        transform.position = new Vector3(0, -3.75f, 10);
    }

    // Update is called once per frame
    void Update()
    {
        cannonSelection = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().whichCannon;

        if (cannonSelection == 1)
        {
            GetComponent<SpriteRenderer>().sprite = CannonSprite1;
        }
        else if (cannonSelection == 2)
        {
            GetComponent<SpriteRenderer>().sprite = CannonSprite2;
        }
        else if (cannonSelection == 3)
        {
            GetComponent<SpriteRenderer>().sprite = CannonSprite3;
        }
        else if (cannonSelection == 4)
        {
            GetComponent<SpriteRenderer>().sprite = CannonSprite4;
        }
        else if (cannonSelection == 5)
        {
            GetComponent<SpriteRenderer>().sprite = CannonSprite5;
        }
        else if (cannonSelection == 6)
        {
            GetComponent<SpriteRenderer>().sprite = CannonSprite6;
        }
        fingerposition = Input.GetTouch(0).position;
        fingerposition.z = 10f;
        fingerposition.y = 10f;
        fingerposition.y = fingerposition.y + 250f;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            transform.position = Camera.main.ScreenToWorldPoint(fingerposition);
            Debug.Log(transform.position);
            frames = frames + 1;
            bulletSpeed = 10;

            if( frames > bulletSpeed)
            {
                Instantiate(bulletInstance, transform.position, transform.rotation);
                frames = 0;
            }
            
        }
        
        //Temporary shoot Button from PC
        if (Input.GetMouseButton(1))
        {
            Debug.Log(transform.position);
            frames = frames + 1;
            bulletSpeed = 10;

            if (frames > bulletSpeed)
            {
                Instantiate(bulletInstance, transform.position, transform.rotation);
                frames = 0;
            }

        }
    }

}

