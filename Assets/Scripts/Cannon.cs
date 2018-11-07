using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Boardgazz : MonoBehaviour
{

    public Vector3 fingerposition;
    public GameObject bulletInstance;
    public int bulletSpeed;
    int frames = 0;

    // Use this for initialization
    void Start()
    {
        Input.multiTouchEnabled = false;
        transform.position = new Vector3(0, -4, 10);
    }

    // Update is called once per frame
    void Update()
    {
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
        
    }

}

