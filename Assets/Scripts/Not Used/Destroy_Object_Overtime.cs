﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Object_Overtime : MonoBehaviour {

	public float lifeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
			Destroy(gameObject);
        }
	}
}
