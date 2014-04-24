using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public bool followed;
	public Vector3 lastposition;
	private GameObject toFollow;
	// Use this for initialization
	void Start () {
		//foreach (GameObject go in GameObject.FindGameObjectsWithTag("Snake")) {
			//Debug.Log ("count");
			Follow segment= GameObject.Find ("Segment(Clone)").GetComponent<Follow>();
			if (segment.followed==false){
				toFollow=GameObject.Find(segment.name);
			}		
		//}

	}
	
	// Update is called once per frame
	void Update () {
		/*lastposition =new Vector3(transform.position.x,transform.position.y,transform.position.z);
		//Debug.Log (toFollow.name);
		toFollow.transform.position = this.lastposition;
		if (Input.GetKey("space")){
			Debug.Log (toFollow.name);
		}*/

	}
}
