using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour {

    //audio variables
    public AudioClip playerCollect;
    public spawnDoor winDoor;

    // Use this for initialization
    void Start()
    {
        GameObject door = GameObject.FindGameObjectWithTag("Door");
        winDoor = door.GetComponent<spawnDoor>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            winDoor.activateDoor();

            Destroy(gameObject); //destroy after sound is done

            AudioSource.PlayClipAtPoint(playerCollect, transform.position); // Fixes audio playing after object is destroyed.
        }
    }
}
