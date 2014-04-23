using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
	public bool followed;
	public Vector3 lastposition;
<<<<<<< HEAD
	public Vector3 followposition;
	public bool followed= false;
	// Use this for initialization
	void Start () {
		if (this.name != "Head(Clone)") {
			Follow piece= GameObject.Find ("Head(Clone)").GetComponent<Follow>();
			piece.followed=true;
		}
=======
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
>>>>>>> parent of 17bd830... follow

	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		if (this.name == "Head(Clone)") {
			if (lastposition != transform.position) {
				lastposition=transform.position;
				followposition=lastposition;
			}
		}
		if (this.name!="Head(Clone)"){
			if (followposition != transform.position) {
				lastposition = transform.position;
				followposition=lastposition;
			}
			Follow piece= GameObject.Find ("Head(Clone)").GetComponent<Follow>();
			transform.position=piece.followposition;
		}
		if (Input.GetKey("space")){
			Debug.Log(lastposition+", "+followposition);
		}

	}
}
/*using System.Collections;

public class Follow : MonoBehaviour {
	public bool followed;
	public Vector3 lastposition;
	private GameObject toFollow;
	public Follow piece;
	// Use this for initialization
	void Start () {
		//foreach (GameObject go in GameObject.FindGameObjectsWithTag("Snake")) {
			//Debug.Log ("count");
			Follow segment= GameObject.Find ("Segment(Clone)").GetComponent<Follow>();
			if (segment.followed==false){
				toFollow=GameObject.Find(segment.name);
			}		
		//}
		if (this.name != "Head(Clone)") {
			piece= GameObject.Find("Head(Clone)").GetComponent<Follow>();

		}
=======
		/*lastposition =new Vector3(transform.position.x,transform.position.y,transform.position.z);
		//Debug.Log (toFollow.name);
		toFollow.transform.position = this.lastposition;
		if (Input.GetKey("space")){
			Debug.Log (toFollow.name);
		}*/
>>>>>>> parent of 17bd830... follow

	}
	
	// Update is called once per frame
	void Update () {
		lastposition =new Vector3(transform.position.x,transform.position.y,transform.position.z);
		//Debug.Log (toFollow.name);
		toFollow.transform.position = this.lastposition;
		if (Input.GetKey("space")){
			Debug.Log (toFollow.name);
		}
if (lastposition != transform.position) {
	lastposition = transform.position;
}
if (this.name != "Head(Clone)") {
	transform.position= piece.lastposition;	
	Debug.Log(lastposition);
}

}
}
*/
