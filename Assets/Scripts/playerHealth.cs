using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject deathFX;

    //HUD variables
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverScreen;

    //audio variables
    public AudioClip playerHurt;
    public AudioClip playerDie;

    float currentHealth;

    AudioSource playerAS;

    Color damagedColor = new Color(0f, 0f, 0f, .9f);
    float smoothColor = 5f;

    //restart Game
    public restartGame theGameManager;


	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;
        
        //HUD Initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        playerAS = GetComponent<AudioSource>();

        
	}
	
	// Update is called once per frame
	void Update () {
        damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
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

    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;

        if(currentHealth > fullHealth)
        {
            currentHealth = fullHealth;
        }
        healthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        currentHealth = 0;
        healthSlider.value = currentHealth;
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDie, transform.position); // Fixes audio playing after object is destroyed.


        //Game Over Screen
        damageScreen.color = damagedColor;
        Animator gameOverAnim = gameOverScreen.GetComponent<Animator>();
        gameOverAnim.SetTrigger("gameOver");
        theGameManager.restartTheGame();
    }

    public void winGame()
    {
        Destroy(gameObject);
        theGameManager.restartTheGame();
    }
}
