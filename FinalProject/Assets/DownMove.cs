using UnityEngine;
using System.Collections;

public class DownMove : MonoBehaviour {

	public bool move=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SnakeMovement head = GameObject.Find ("Head(Clone)").gameObject.GetComponent<SnakeMovement> ();
		transform.position = head.transform.position + new Vector3 (0, -.75f, 0);
		
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "Wall(Clone)"){
			move=true;
		}
		if (other.name == "Segment(Clone)") {
			move=true;
		}
	}
	void OnTriggerExit(){
		move = false;
	}
}
