using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHealth playerFell = other.GetComponent<playerHealth>();
            playerFell.makeDead();
        }else
        {
            Destroy(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {

    }
}
