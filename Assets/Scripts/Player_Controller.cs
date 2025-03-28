﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{


	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckradius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	/*
	private Animator anim;

	public Transform firePoint;
	public GameObject Rock;
	*/

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;


	// Use this for initialization
	void Start()
	{
		//anim = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckradius, whatIsGround);
	}

	// Update is called once per frame
	void Update()
	{
		if (!inDialogue())
		{
			if (grounded)
			{
				doubleJumped = false;
			}
			//anim.SetBool("Grounded", grounded);

			if (GetComponent<Rigidbody2D>().velocity.x > 0)

				transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
			else if (GetComponent<Rigidbody2D>().velocity.x < 0)
				transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);

			moveVelocity = 0f;
			if (Input.GetKeyDown(KeyCode.Space) && grounded)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			}

			//Double Jump
			/*
			if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
				doubleJumped = true;
			}
			*/
			//moveVelocity = moveSpeed = Input.GetAxisRaw("Horizontal"); 


			if (Input.GetKey(KeyCode.D))
			{
				//GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
				moveVelocity = moveSpeed;
			}

			if (Input.GetKey(KeyCode.A))
			{
				//GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
				moveVelocity = -moveSpeed;
			}


			/*if (Input.GetKeyDown(KeyCode.O)){
				Instantiate(Rock, firePoint.position, firePoint.rotation);
			}*/

			if (knockbackCount < 0)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
			}
			else
			{
				if (knockFromRight)
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, 1f);
				}
				if (!knockFromRight)
				{
					GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, 1f);
				}
				knockbackCount -= Time.deltaTime;
			}
			/*
			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

			if (anim.GetBool("melee"))
				anim.SetBool("melee", false);
			if (Input.GetKey(KeyCode.L))
			{
				anim.SetBool("melee", true);
			}*/

		}else{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f,0f); 
		}
	}
	private NPC_Controller npc;
	private void OnTriggerStay2D(Collider2D collision)
	{ // Talks when u enter collision
		if (collision.gameObject.tag == "NPC")
		{

			npc = collision.gameObject.GetComponent<NPC_Controller>();
			npc.ActivateDialogueBoxE();
			if (Input.GetKey(KeyCode.E))
			{

				npc.ActivateDialogue();
			}
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{ // knows hen u exit.
	
		if (collision.gameObject.tag == "NPC")
		{
			npc.CloseDialogueBoxE();
			npc = null;
		}
	}
	private bool inDialogue()
	{
		if (npc != null)
		{
			return npc.DialogueActivate();
		}
		else
		{
			return false;
		}
	}
}
