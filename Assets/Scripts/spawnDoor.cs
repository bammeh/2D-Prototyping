using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDoor : MonoBehaviour {

    bool activated = false;
    public Transform wheretoSpawn;
    public GameObject door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !activated)
        {
            activated = true;
            Instantiate(door, wheretoSpawn.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
