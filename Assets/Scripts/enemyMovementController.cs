using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {
    
    public float enemySpeed;
    
    //Animator enemyAnimator;

    //facing
    public GameObject enemyGraphic;
    bool canFlip = true;
    bool facingRight = false; //Mob is facing left by default
    float flipTime = 5f; //chance to flip every 5 seconds
    float nextFlipChance = 0f; //Can flip right away by default

    //attacking
    public float chargeTime; //Delay before mob charges player
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyRB;

	// Use this for initialization
	void Start () {
        //enemyAnimator.GetComponentInChildren<Animator>(); // Add for animation 
        enemyRB = GetComponent<Rigidbody2D>();
         
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextFlipChance)
        {
            if (Random.Range(0,10) >= 5)
            {
                flipFacing();
            
            }
            nextFlipChance = Time.time + flipTime;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") //make sure that enemy only charges at Players
        {
            if(facingRight && other.transform.position.x < transform.position.x) //If enemy facing right and is Player Behind enemy
            {
                flipFacing(); // flip to left

            } else if (!facingRight && other.transform.position.x > transform.position.x) //If enemy is facing left and player is behind enemy
            {
                flipFacing(); //flip to right
            }
            canFlip = false; //No more flipping
            charging = true; //Begin to charge
            startChargeTime = Time.time + chargeTime; //Determine when to actually start running. Allow player time to react.
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player") //make sure that enemy only charges at Players
        {
            if (chargeTime < Time.time) //once time is greater than charge time, start charging
            {
                if (!facingRight) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed); // If facing left, charge left at enemyspeed
                else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed); // if facing right, charge right at enemySpeed
                //enemyAnimator.SetBool("isCharging", charging); //change animation to running animation
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")//make sure that enemy only charges at Players
        {
            canFlip = true; // allow enemy to begin flipping again
            charging = false; //Stop charging
            enemyRB.velocity = new Vector2(0f, 0f); //Stop enemy movement
            //enemyAnimator.SetBool("isCharging", charging); //change animation to idle animation
        }
    }

    void flipFacing()
    {
        if (!canFlip) //if we cant flip, get out of here
        {
            return;
        }
        float facingX = enemyGraphic.transform.localScale.x; //Current X
        facingX *= -1f; //Flip negative across x axis.
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z); //Flip the enemyGraphic to proper direction
        facingRight = !facingRight; //flip value of facingRight
    }
}
