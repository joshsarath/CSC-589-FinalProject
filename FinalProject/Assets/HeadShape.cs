using UnityEngine;
using System.Collections;

public class HeadShape : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		SnakeMovement head = GameObject.Find ("Head(Clone)").gameObject.GetComponent<SnakeMovement> ();
		transform.position = head.transform.position + new Vector3 (0, 0, 0);
		
	}

}