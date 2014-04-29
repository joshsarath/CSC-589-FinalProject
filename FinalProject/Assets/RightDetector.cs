using UnityEngine;
using System.Collections;

public class RightDetector : MonoBehaviour {
	public bool move=false;//will allow head to move in that direction
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
