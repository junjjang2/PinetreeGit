using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	
	public 	GameObject maker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		Destroy (col.gameObject);
		maker.GetComponent<MakeBlock> ().Destroy ();
		print ("GameOver");
	}
}
