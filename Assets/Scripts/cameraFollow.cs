using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow: MonoBehaviour
{

    public Camera cameraMain; // What camera is following
    public float smoothing; //dampening effect

    Vector3 offset;

    float lowY; // Lowest point camera can go on Y axis

    // Use this for initialization
    void Awake()
    {

    }
    void Start()
    {
        offset = cameraMain.transform.position - transform.position; // what is difference of the two? Lets maintain that.
        lowY = cameraMain.transform.position.y; // current position of camera.

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = transform.position + offset; // Where camera wants to be located.

        cameraMain.transform.position = Vector3.Lerp(cameraMain.transform.position, targetCamPos, smoothing * Time.deltaTime); // Change position from Current position to target position at the rate of smoothing times deltaTime.

        if (cameraMain.transform.position.y < lowY) // If position is lower than lowY, then pop back up
        {
            cameraMain.transform.position = new Vector3(cameraMain.transform.position.x, lowY, cameraMain.transform.position.z);
        }
    }


}