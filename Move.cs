using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	float timer;
	int length = 4;
	float speed;
	bool turn = false; //
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
			
		if (timer < length / speed) {
			this.transform.Translate (direction * speed * Time.deltaTime);
			timer += Time.deltaTime;
		} else {
			timer = 0; //if code is completed, remove this
			reverseDirection ();
		
			//turn = false;
		}

		if (turn & Input.GetMouseButtonDown (0)) {
			direction.x = 0;
			direction.y = -1;
			direction.z = 0;
			speed = 2f;
		}
	}

	public void setTurn(bool t){
		timer = 0;
		turn = t;
	}


	void OnTriggerEnter(Collider col){

	}

	// Use this when next level
	public void changeSpeed(float speed){
		this.speed = speed;
	}

	public void setDirection(Vector3 dir){
		direction = dir;
	}

	void reverseDirection(){
		direction.x *= -1;
		direction.z *= -1;
	}

}
