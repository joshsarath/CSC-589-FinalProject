using UnityEngine;
using System.Collections;

public class RightMove : MonoBehaviour {
	public bool move=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SnakeMovement head = GameObject.Find ("Head(Clone)").gameObject.GetComponent<SnakeMovement> ();
		transform.position = head.transform.position + new Vector3 (0, .75f, 0);
		
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "Wall(Clone)"){
			move=true;
		}
		if (other.name == "Segment(Clone)") {
			//Debug.Log ("collided");
			move=true;
		}
	}
	void OnTriggerExit(){
		move = false;
	}
}

