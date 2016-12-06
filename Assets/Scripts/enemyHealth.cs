using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    public GameObject enemyDeathFX;

    public bool drops;
    public GameObject theDrop;
    
    //HUD variables
    public Slider enemyHealthSlider;

    float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;

        //HUD Initialization
        enemyHealthSlider.maxValue = enemyMaxHealth;
        enemyHealthSlider.value = enemyMaxHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        enemyHealthSlider.gameObject.SetActive(true);

        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(gameObject.transform.parent.gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops) //ADD A RANDOMIZATION HERE SO NOT EVERY MOB DROPS HEALTH
        {
            Instantiate(theDrop, transform.position, transform.rotation);
            
        }
        
    }
}
