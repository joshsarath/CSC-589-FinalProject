using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void Start () {
		ymax = 1000;
		ymin=-1000;
		xmax = 1000;
		xmin = -1000;
	}
	
	// Update is called once per frame
	void Update () {
		//if (counter<=0){
			if (Input.GetKey ("up")) {
				if (transform.position.y<=ymax){
					yspeed=moveunit;
					transform.position+=new Vector3(0,yspeed,0);
					xspeed=0;
					yspeed=0;
					lastKey=0;
					//counter=timedelay;
				}
			}
			if (Input.GetKey ("down")) {
				if (transform.position.y>=ymin){
					yspeed=moveunit;
					transform.position-=new Vector3(0,yspeed,0);
					xspeed=0;
					yspeed=0;
					lastKey=0;
					//counter=timedelay;
				}
			}
			if (Input.GetKey ("left")) {
				if (transform.position.x>=xmin){
					xspeed=moveunit;
					transform.position-=new Vector3(xspeed,0,0);
					xspeed=0;
					yspeed=0;
					lastKey=1;
					//counter=timedelay;
				}
			}
			if (Input.GetKey ("right")) {
				if (transform.position.x<=xmax){
					xspeed=moveunit;//sets speed to constant unit
					transform.position+=new Vector3(xspeed,0,0);//changes position on new 1 directional vector3
					xspeed=0;//resets speed to 0 so after key lifted no more movement
					yspeed=0;
					lastKey=1;
					//counter=timedelay;
				}
			}

		//}
		//counter-=Time.deltaTime;
		//Debug.Log (counter);
	}
	void OnTriggerEnter(Collider other){

		if (other.name == "Food(Clone)") {
			//Debug.Log ("poop");
			Destroy(other.gameObject);
			Instantiate(snakeSegment);
			//transform.position=new Vector3((other.transform.position.x-.5f), transform.position.y,0);  
			//Destroy (gameObject);
		}
		if (other.name=="Segment(Clone)"){
			Destroy (other.gameObject);
			Destroy (this.gameObject);
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
}
