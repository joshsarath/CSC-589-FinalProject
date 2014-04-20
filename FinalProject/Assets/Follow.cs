using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public Vector3 lastposition;
	public Follow piece;
	// Use this for initialization
	void Start () {
		if (this.name != "Head(Clone)") {
			piece= GameObject.Find("Head(Clone)").GetComponent<Follow>();

		}

	}
	
	// Update is called once per frame
	void Update () {
		if (lastposition != transform.position) {
			lastposition = transform.position;
		}
		if (this.name != "Head(Clone)") {
			transform.position= piece.lastposition;	
			Debug.Log(lastposition);
		}

	}
}
