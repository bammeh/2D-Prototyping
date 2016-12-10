using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour {

    Transform target; // What camera is following
    public float smoothing; //dampening effect

    Vector3 offset;

    float lowY; // Lowest point camera can go on Y axis

	// Use this for initialization
    void Awake()
    {
        //GameObject player = GameObject.FindWithTag("Player");
        
       //GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.Find("Player").transform;
       // target = player.transform;
        //target = transform.Find("Player");
    }
	void Start () {
        offset = transform.position - target.position; // what is difference of the two? Lets maintain that.
        lowY = transform.position.y; // current position of camera.

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset; // Where camera wants to be located.

        transform.position = Vector3.Lerp(transform.position,targetCamPos,smoothing * Time.deltaTime); // Change position from Current position to target position at the rate of smoothing times deltaTime.
        
        if(transform.position.y < lowY) // If position is lower than lowY, then pop back up
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
	}


}
