﻿using UnityEngine;
using System.Collections;

public class StartSnake : MonoBehaviour {
	public GameObject snake;
	public GameObject food;
	public GameObject wall;
	public int arena =20;
	public int score=0;
	public GUIStyle style;
	public int foodleft;


	// Use this for initialization
	void Start () {
		startsnake (arena);
	}
	
	// Update is called once per frame
	void Update () {
		if (foodleft == 0) {
			fertilize(arena);		
		}
	
	}
	void startsnake(int size){
		Instantiate (snake);
		Instantiate (wall);
		buildWalls (arena);
		fertilize (arena);

	}
	void buildWalls( int size){
		GameObject top = Instantiate (wall, new Vector3 (0, (arena/2), 0), Quaternion.identity) as GameObject;
		top.transform.localScale = new Vector3 (20,.5f,1);
		GameObject bottom = Instantiate (wall, new Vector3 (0, -(arena/2), 0), Quaternion.identity) as GameObject;
		bottom.transform.localScale = new Vector3 (20,.5f,1);
		GameObject right = Instantiate (wall, new Vector3 ((arena/2), 0, 0), Quaternion.identity) as GameObject;
		right.transform.localScale = new Vector3 (.5f,20,1);
		GameObject left = Instantiate (wall, new Vector3 (-(arena/2), 0, 0), Quaternion.identity) as GameObject;
		left.transform.localScale = new Vector3 (.5f,20,1);
		for (int i=0; i<arena; i++) {
			Vector3 position=new Vector3( Random.Range((-arena/2)+1, (arena/2)-1), Random.Range((-arena/2)+1, (arena/2)-1),0);
			Instantiate (wall, position, Quaternion.identity);
		}
	}
	void fertilize( int arena){
		for (int i=0; i<arena/2; i++) {
			Vector3 position=new Vector3( Random.Range((-arena/2)+1, (arena/2)-1), Random.Range((-arena/2)+1, (arena/2)-1),0);
			Instantiate (food, position, Quaternion.identity);
		}
		foodleft = arena / 2;
	}
	
	void OnGUI(){

			GUI.Label (new Rect(0,0,400,200), ("Score: "+ score), style);

	}
}