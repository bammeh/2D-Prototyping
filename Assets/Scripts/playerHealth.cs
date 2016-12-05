using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject deathFX;

    //HUD variables
    public Slider healthSlider;

    //audio variables
    public AudioClip playerHurt;
    public AudioClip playerDie;

    float currentHealth;

    playerController controlMovement;
    SpriteRenderer renderer;
    Rigidbody2D myRB;
    

    AudioSource playerAS;


	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();
        renderer = GetComponent<SpriteRenderer>();
        myRB = GetComponent<Rigidbody2D>();


        //HUD Initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        playerAS = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        if (damage <= 0)
        {
            return;
        }
      
        currentHealth -= damage;

        playerAS.clip = playerHurt;
        playerAS.PlayOneShot(playerHurt);

        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {

            makeDead();
        }
    }

    public void makeDead()
    {
        
        controlMovement.enabled = false; // once dead, you cant move.
        myRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY; // make ssure player doesnt get knockback once dead.
        renderer.enabled = false; //once dead, hide the sprite

        playerAS.clip = playerDie;
        playerAS.PlayOneShot(playerDie);
               
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject,.5f);
              
        
    }
}
