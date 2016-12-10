using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRoam : MonoBehaviour {

    public LayerMask enemyMask;
    public float speed;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

	// Use this for initialization
	void Start () {
        myTrans = this.transform;
        myBody = GetComponent<Rigidbody2D>();
        myWidth = GetComponentInChildren<CircleCollider2D>().radius / 2;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //check to see if there's ground in front of us before moving forward
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth*2;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        //if theres ground, turn around
        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        //Always move Forward
        Vector2 myVel = myBody.velocity;
        myVel.x = myTrans.right.x * speed;
        myBody.velocity = myVel;
	}
}
