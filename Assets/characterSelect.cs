using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelect : MonoBehaviour {


    public Transform wheretoSpawnPlayer;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    

    // Use this for initialization
    void Start () {
        int character = PlayerPrefs.GetInt("character");
        if (character == 0)
        {
            player1.SetActive(true);
            player3.SetActive(false);
            player2.SetActive(false);
            //Instantiate(player1, wheretoSpawnPlayer.position, Quaternion.identity);
            //Destroy(gameObject);
        }
        if (character == 1)
        {
            player2.SetActive(true);
            player1.SetActive(false);
            player3.SetActive(false);
            //Instantiate(player2, wheretoSpawnPlayer.position, Quaternion.identity);
            //Destroy(gameObject);
        }
        if (character == 2)
        {
            player3.SetActive(true);
            player1.SetActive(false);
            player2.SetActive(false);
            //Instantiate(player3, wheretoSpawnPlayer.position, Quaternion.identity);
            //Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
