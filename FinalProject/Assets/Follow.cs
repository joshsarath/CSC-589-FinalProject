using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public GameObject toFollow;
	public bool followed=false;
	public Vector3 lastposition;
	// Use this for initialization
	void Start () {
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Snake")) {
			Follow segment= GameObject.Find (go.name).GetComponent<Follow>();
			if (segment.followed==false){
				toFollow=segment.gameObject;
			}		
		}
	}
	
	// Update is called once per frame
	void Update () {
		lastposition = transform.position;
		transform.position = toFollow.transform.position;
	}
}
