using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeMovement : MonoBehaviour {

	private float xspeed;
	private float yspeed;
	public float moveunit;//constant unit to adjust speed
	public GameObject snakeSegment;
	//private float counter;
	//public float timedelay;
	private float ymax;
	private float ymin;
	private float xmax;
	private float xmin;
	private int lastKey;/*directional memory for collisions 1 is side to side, 0 is up down*/
	private float counter;
	public float timeDelay=.5f;
	public Vector3 lastposition;
	public List<GameObject> list;

	// Use this for initialization
	void Start () {
		counter = 0;
		ymax = 1000;
		ymin = -1000;
		xmax = 1000;
		xmin = -1000;
		list = new List<GameObject> ();
		list.Add(GameObject.Find("Head(Clone)"));
	}
	
	// Update is called once per frame
	void Update () {
		if (this.name=="Head(Clone)"){
			if (counter<=0){
				if (Input.GetKey ("up")) {
					if (transform.position.y<=ymax){

						//lastposition=transform.position;
						counter=1;
						follow ();
						yspeed=moveunit;
						transform.position+=new Vector3(0,yspeed,0);
						xspeed=0;
						yspeed=0;
						lastKey=0;
						counter=timeDelay;

						//counter=timedelay;
					}
				}
				if (Input.GetKey ("down")) {
					if (transform.position.y>=ymin){
						counter=1;
						follow ();
						yspeed=moveunit;
						transform.position-=new Vector3(0,yspeed,0);
						xspeed=0;
						yspeed=0;
						lastKey=0;
						counter=timeDelay;
					}
				}
				if (Input.GetKey ("left")) {
					if (transform.position.x>=xmin){
						counter=1;
						follow ();
						xspeed=moveunit;
						transform.position-=new Vector3(xspeed,0,0);
						xspeed=0;
						yspeed=0;
						lastKey=1;
						counter=timeDelay;
						//counter=timedelay;
					}
				}
				if (Input.GetKey ("right")) {
					if (transform.position.x<=xmax){
						counter=1;
						follow ();
						xspeed=moveunit;//sets speed to constant unit
						transform.position+=new Vector3(xspeed,0,0);//changes position on new 1 directional vector3
						xspeed=0;//resets speed to 0 so after key lifted no more movement
						yspeed=0;
						lastKey=1;
						counter=timeDelay;
					}
				}
			}
				counter-=Time.deltaTime;
				//Debug.Log (counter);
		}
		else{
			lastposition=transform.position;
		}
	}
	void OnTriggerEnter(Collider other){

		if (other.name == "Food(Clone)") {
			//Debug.Log ("poop");
			Destroy(other.gameObject);
			GameObject instance;
			instance=Instantiate(snakeSegment) as GameObject;
			list.Add(instance.gameObject);
			//transform.position=new Vector3((other.transform.position.x-.5f), transform.position.y,0);  
			//Destroy (gameObject);
		}
		if (other.name=="Segment(Clone)"){
			//Destroy (other.gameObject);
			//Destroy (this.gameObject);
		}
		if (other.name == "Wall(Clone)") {
			/* stop movememt entirely 
			 * or end game if too difficult
			 */
			if (lastKey==0){
				ymax=transform.position.y;
				ymin=transform.position.y;
			}
			if (lastKey==1){
				xmax=transform.position.x;
				xmin=transform.position.x;
			}
		}
	}
	void OnTriggerExit(){
		ymax = 1000;
		ymin=-1000;
		xmax = 1000;
		xmin = -1000;
	}

	void follow(){
		/*int length = GameObject.FindGameObjectsWithTag ("Snake").Length;
		Debug.Log (length);
		GameObject[] array=new GameObject[length];
		int i=0;
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Snake")) {
			array[i]=go.gameObject;
			i++;
		}
		for (int j=1; j<=length; length++) {
			SnakeMovement follow= array[j-1].gameObject.GetComponent<SnakeMovement>();
			array[j].gameObject.transform.position=follow.lastposition;
		}*/
		/*for (int i=1; i<=list.Count; i++) {
			SnakeMovement follow=(SnakeMovement) list[i].GetComponent<SnakeMovement>();
			SnakeMovement tofollow=(SnakeMovement)list[i-1].GetComponent<SnakeMovement>();
			follow.transform.position=tofollow.lastposition;
		}*/
		for (int i=1; i<list.Count;i++){
			SnakeMovement piece = list[i-1].gameObject.GetComponent<SnakeMovement> ();
			piece.lastposition = piece.transform.position;
			list[i].transform.position = piece.lastposition;
			Debug.Log (list[1].name);
		}
	}
}
