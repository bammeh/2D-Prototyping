using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour {

    public float healthAmount;

    //audio variables
    public AudioClip playerCollect;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            playerHealth theHealth = other.gameObject.GetComponent<playerHealth>();

            theHealth.addHealth(healthAmount); //increase health
            Destroy(gameObject); //destroy after sound is done

            AudioSource.PlayClipAtPoint(playerCollect, transform.position); // Fixes audio playing after object is destroyed.
        }
    }
}
