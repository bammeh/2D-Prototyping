using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour {

    public float healthAmount;

    //audio variables
    public AudioClip playerCollect;

    AudioSource playerAS;
    SpriteRenderer renderer;

    // Use this for initialization
    void Start () {
        playerAS = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            renderer.enabled = false; //once collected, hide the sprite
            
            playerAS.PlayOneShot(playerCollect); //play sound
            playerHealth theHealth = other.gameObject.GetComponent<playerHealth>();

            theHealth.addHealth(healthAmount); //increase health
            Destroy(gameObject, playerCollect.length); //destroy after sound is done
        }
    }
}
