using UnityEngine;
using System.Collections;

public class StartSnake : MonoBehaviour {
	public GameObject snake;
	public GameObject food;
	public GameObject wall;
	public int arena =20;
	// Use this for initialization
	void Start () {
		startsnake (arena);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void startsnake(int size){
		Instantiate (snake);
		Instantiate (food,new Vector3 (-2, -2, 0), Quaternion.identity);
		Instantiate (wall);
		Instantiate (food, new Vector3 (2, 2, 0), Quaternion.identity);
		buildWalls (arena);
		fertilize ();

	}
	void buildWalls( int size){
		GameObject top = Instantiate (wall, new Vector3 (0, (arena/2), 0), Quaternion.identity) as GameObject;
		top.transform.localScale = new Vector3 (20,5,1);
		GameObject bottom = Instantiate (wall, new Vector3 (0, -(arena/2), 0), Quaternion.identity) as GameObject;
		bottom.transform.localScale = new Vector3 (20,.5f,1);
		GameObject right = Instantiate (wall, new Vector3 ((arena/2), 0, 0), Quaternion.identity) as GameObject;
		right.transform.localScale = new Vector3 (.5f,20,1);
		GameObject left = Instantiate (wall, new Vector3 (-(arena/2), 0, 0), Quaternion.identity) as GameObject;
		left.transform.localScale = new Vector3 (.5f,20,1);
	}
	void fertilize(){

	}
}