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

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
