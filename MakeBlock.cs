using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBlock : MonoBehaviour {

	float mins, maxs;
	public Material[] Color= new Material[11];
	public GameObject block;
	public GameObject Dummy;
	public GameObject BG;
	Dictionary<int,Vector3[]> bPos = new Dictionary<int, Vector3[]>();
	GameObject[] blocks = new GameObject[4];

	// Use this for initialization
	void Start () {
		mins = 1f;
		maxs = 1.2f;

		bPos.Add(0, new Vector3[2]{ new Vector3 (2, 0, 0), new Vector3 (-1, 0, 0) }); //bPos['U'][0]=block's position
		bPos.Add(1, new Vector3[2]{ new Vector3 (-2, 0, 0), new Vector3 (1, 0, 0) }); //bPos['U'][1]=block's direction
		bPos.Add(2, new Vector3[2]{ new Vector3 (0, 0, -2), new Vector3 (0, 0, 1) });
		bPos.Add(3, new Vector3[2]{ new Vector3 (0, 0, 2), new Vector3 (0, 0, -1) });

		blocks[0] = (GameObject) Instantiate (block, bPos[0][0], this.transform.rotation); //LEFT DOWN SIDE
		blocks[1] = (GameObject) Instantiate (block, bPos[1][0], this.transform.rotation); //RIGHT UP
		blocks[2] = (GameObject) Instantiate (block, bPos[2][0], this.transform.rotation); //LEFT DOWN
		blocks[3] = (GameObject) Instantiate (block, bPos[3][0], this.transform.rotation); //RIGHT UP

		for (int i=0; i<4; i++)
			blocks [i].SetActive (false); //Deactivate All Block

		make ();
	}

	// Update is called once per frame
	void Update () {

	}

	void make(){
		int[] seq = shuffle ();

		for (int i=0; i<3; i++){
			GameObject b = blocks [seq [i]];
			b.GetComponent<MeshRenderer> ().material = Color[Random.Range(0, 11)]; 
			b.transform.position = bPos[seq[i]][0]+this.transform.position;
			b.transform.Translate (new Vector3 (0, 0.5f+0.001f*i,0));//+0.5f+0.0001f*i, 0));
			b.GetComponent<Move>().setDirection(bPos[seq[i]][1]);
			b.GetComponent<Move>().changeSpeed (changeBlockSpeed());
			b.SetActive(true);
		}
		blocks[seq[1]].GetComponent<Move>().setTurn(true); //Select One Block To Drop
		BG.GetComponent<MeshRenderer>().material=blocks[seq[1]].GetComponent<MeshRenderer>().material;


	}

	// Use this when next level
	float changeBlockSpeed(){
		mins += 0.1f;
		maxs += 0.1f;
		return Random.Range (mins, maxs);
	}

	void OnTriggerEnter(Collider col){
		Invoke ("make", 0.1f);
		makeDummy (col);

		for (int i = 0; i < 4; i++) {
			blocks [i].SetActive (false);
			blocks [i].GetComponent<Move> ().setTurn (false);
		}
	}
		
	void makeDummy(Collider col){
		col.gameObject.SetActive (false);
		Vector3 pos = col.transform.position;
		pos.y =this.transform.position.y+0.05f;
		Dummy.GetComponent<MeshRenderer> ().material = col.GetComponent<MeshRenderer>().material;
		Instantiate (Dummy, pos, col.transform.rotation);
	}

	public void Destroy(){
		for (int i= 0; i<4; i++){
			Destroy(blocks[i]);
		}
		Destroy(this);
	}
		
	int[] shuffle()	{
		int[] data = { 0, 1, 2, 3 };
		int size = 4;
		int temp = 0;

		for (int i = 0; i < size; ++i) {

			int randNum = Random.Range(0, size - 1);

			temp = data[randNum];

			data[randNum] = data[i];

			data[i] = temp;

		}
		return data;
	}

}