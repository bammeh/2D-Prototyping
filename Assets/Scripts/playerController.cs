using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    SpriteRenderer mySR;
    bool facingRight;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;


	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        mySR = GetComponent<SpriteRenderer>();

        facingRight = true;
        
	}
    //Once Per Frame
    void Update()
    {
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

        // Player shooting
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireRocket();
        }
    }
	
	
	void FixedUpdate () {

        //check if we are grounded. If no, then we are falling.
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed",myRB.velocity.y);


        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed",Mathf.Abs(move));

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        } else if (move < 0 && facingRight)
        {
            flip();
        }


    }
    void flip()
    {
        facingRight = !facingRight;
        //Vector3 localPos = gunTip.transform.localPosition;
        //gunTip.transform.localPosition *= -1;
        gunTip.transform.localPosition = new Vector3(gunTip.transform.localPosition.x * -1, 0, 0); // Make sure gunTip flips when Player flips.
        mySR.flipX = !mySR.flipX; //Flips player on X Axis.

    }

    void fireRocket()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet,gunTip.position,Quaternion.Euler(new Vector3(0,0,0)));
            } else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
