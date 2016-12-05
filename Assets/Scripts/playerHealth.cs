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
    

    AudioSource playerAS;


	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;
        controlMovement = GetComponent<playerController>();
        renderer = GetComponent<SpriteRenderer>();
        

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
        
        playerAS.clip = playerDie;
        
        playerAS.PlayOneShot(playerDie);
        renderer.enabled = false;
        controlMovement.enabled = false;
        
        
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject,.8f);
              
        
    }
}
