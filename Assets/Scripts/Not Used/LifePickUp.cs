using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour {

	private Life_Manager lifeSystem;

	// Use this for initialization
	void Start () {

		lifeSystem = FindObjectOfType<Life_Manager>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {

		if (other.name == "Player")
        {
			lifeSystem.GiveLife();
            Destroy(gameObject);
        }
	}
}
