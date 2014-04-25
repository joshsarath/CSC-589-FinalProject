using UnityEngine;
using System.Collections;

public class StartSnake : MonoBehaviour {
	public GameObject snake;
	public GameObject food;
	public GameObject wall;
	// Use this for initialization
	void Start () {
		Instantiate (snake);
		Instantiate (food);
		Instantiate (wall);
		Instantiate (food, new Vector3 (2, 2, 0), Quaternion.identity);
		buildWalls ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void buildWalls(){
		GameObject top = Instantiate (wall, new Vector3 (0, 10, 0), Quaternion.identity) as GameObject;
		top.transform.localScale = new Vector3 (20,.5f,1);
		GameObject bottom = Instantiate (wall, new Vector3 (0, -10, 0), Quaternion.identity) as GameObject;
		bottom.transform.localScale = new Vector3 (20,.5f,1);
		GameObject right = Instantiate (wall, new Vector3 (10, 0, 0), Quaternion.identity) as GameObject;
		right.transform.localScale = new Vector3 (.5f,20,1);
		GameObject left = Instantiate (wall, new Vector3 (-10, 0, 0), Quaternion.identity) as GameObject;
		left.transform.localScale = new Vector3 (.5f,20,1);
	}
}