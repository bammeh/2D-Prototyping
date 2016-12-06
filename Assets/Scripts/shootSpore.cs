using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpore : MonoBehaviour {

    public GameObject theProjectile;
    public float shootTime;
    public Transform shootFrom;
    public int chanceShoot;

    float nextShootTime;
    Animator cannonAnim;

	// Use this for initialization
	void Start () {
        //cannonAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && nextShootTime < Time.time) //Make sure only player is targeted. Make sure nextShootTime is LESS than current time.
        {
            nextShootTime = Time.time + shootTime; //Set shoot time
            if (Random.Range(0, 10) >= chanceShoot) // If chance Shoot is less than these numbers, then shoot.
            {
                Instantiate(theProjectile, shootFrom.position,Quaternion.identity);
                //cannonAnim.SetTrigger("cannonShoot");
            }
        }
    }
}
