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
		Instantiate (food, new Vector3 (-2, -2, 0), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
