using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makerMove : MonoBehaviour {

	public GameObject main;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		Vector3 colPos = col.transform.position;
		colPos.y = main.transform.position.y+0.1f;
		main.transform.position = colPos;

	}
}
