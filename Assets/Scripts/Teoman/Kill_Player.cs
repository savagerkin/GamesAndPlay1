using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_Player : MonoBehaviour {
	public Animator animator;
	public Level_Manager level_manager;

	// Use this for initialization
	void Start () {
		level_manager = FindObjectOfType<Level_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player")
        {
			animator.SetTrigger("damageTAKEN");
			level_manager.RespawnPlayer();
        } 
    }
}
