﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

	public GameObject tower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {

		tower.transform.Translate (new Vector3 (0f, 0.1f, 0f));
	
	}


}
