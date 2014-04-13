using UnityEngine;
using System.Collections;

public class SnakeMovement : MonoBehaviour {

	private float xspeed;
	private float yspeed;
	public float moveunit;//constant unit to adjust speed


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up")) {
			yspeed=moveunit;
			transform.position+=new Vector3(0,yspeed,0);
			xspeed=0;
			yspeed=0;
		}
		if (Input.GetKey ("down")) {
			yspeed=moveunit;
			transform.position-=new Vector3(0,yspeed,0);
			xspeed=0;
			yspeed=0;
		}
		if (Input.GetKey ("left")) {
			xspeed=moveunit;
			transform.position-=new Vector3(xspeed,0,0);
			xspeed=0;
			yspeed=0;
		}
		if (Input.GetKey ("right")) {
			xspeed=moveunit;//sets speed to constant unit
			transform.position+=new Vector3(xspeed,0,0);//changes position on new 1 directional vector3
			xspeed=0;//resets speed to 0 so after key lifted no more movement
			yspeed=0;
		}
	}
	void OnTriggerEnter(Collider other){
		/*
		if (other.name == "Cube") {
			Debug.Log ("poop");
			transform.position+=new Vector3(0,0,0);
			//transform.position=new Vector3((other.transform.position.x-.5f), transform.position.y,0);  
			//Destroy (gameObject);
		}
*/
	}
}
