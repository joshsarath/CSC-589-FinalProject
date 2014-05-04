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

	private int lastKey;/*directional memory for collisions 1 is side to side, 0 is up down*/
	private float counter;
	public float timeDelay=.5f;
	public Vector3 lastposition;
	public List<GameObject> list;
	public bool followed=false;
	public StartSnake game;
	public GameObject bufferpiece;

	// Use this for initialization
	void Start () {


	
		if (this.name =="Head(Clone)"){ 
			counter = 0;
			
			list = new List<GameObject> ();//create list of snake part	
			list.Add(GameObject.Find("Head(Clone)"));//add head to list
			followed=true;	//set followed to true on head
			GameObject buffer; 
			buffer=Instantiate(bufferpiece, new Vector3(0, 0, -100), Quaternion.identity) as GameObject;
			list.Add (buffer); //add a buffer object to separate head from first snake segment
			followed=true;	//set followed to true on head
			SnakeMovement bufferobject= buffer.gameObject.GetComponent<SnakeMovement>();
			bufferobject.followed=true;
			GameObject buffer2; 
			buffer2=Instantiate(bufferpiece, new Vector3(0, 0, -100), Quaternion.identity) as GameObject;
			list.Add (buffer2); //add a buffer object to separate head from first snake segment

			SnakeMovement bufferobject2= buffer.gameObject.GetComponent<SnakeMovement>();
			bufferobject2.followed=true;
		}



	}
	// Update is called once per frame
	void Update () {
		if (this.name=="Head(Clone)"){
			if (counter<=0){
				if (Input.GetKey ("up")) {
					UpMove movement= GameObject.Find ("Up").gameObject.GetComponent<UpMove>();
					if (movement.move==false){

						//lastposition=transform.position;
						counter=1;

						yspeed=moveunit;
						transform.position+=new Vector3(0,yspeed,0);
						xspeed=0;
						yspeed=0;
						lastKey=0;
						counter=timeDelay;
						follow ();

						//counter=timedelay;
					}
				}
				if (Input.GetKey ("down")) {
					DownMove movement= GameObject.Find ("Down").gameObject.GetComponent<DownMove>();
					if (movement.move==false){
						counter=1;

						yspeed=moveunit;
						transform.position-=new Vector3(0,yspeed,0);
						xspeed=0;
						yspeed=0;
						lastKey=0;
						counter=timeDelay;
						follow ();
					}
				}
				if (Input.GetKey ("left")) {
					LeftMove movement= GameObject.Find ("Left").gameObject.GetComponent<LeftMove>();
					if (movement.move==false){
						counter=1;
					
						xspeed=moveunit;
						transform.position-=new Vector3(xspeed,0,0);
						xspeed=0;
						yspeed=0;
						lastKey=1;
						counter=timeDelay;
						follow ();

					}
				}
				if (Input.GetKey ("right")) {
					RightMove movement= GameObject.Find ("Right").gameObject.GetComponent<RightMove>();
					if (movement.move==false){
						counter=1;
					
						xspeed=moveunit;//sets speed to constant unit
						transform.position+=new Vector3(xspeed,0,0);//changes position on new 1 directional vector3
						xspeed=0;//resets speed to 0 so after key lifted no more movement
						yspeed=0;
						lastKey=1;
						counter=timeDelay;
						follow ();
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
		if (this.name=="Head(Clone)"){
			if (other.name == "Food(Clone)") {

				Destroy(other.gameObject);
				GameObject instance;
				instance=Instantiate(snakeSegment, new Vector3(0, 0, -100), Quaternion.identity) as GameObject;
				//Instantiate(snakeSegment);
				//GameObject instance= GameObject.Find ("Segment(Clone)");
				list.Add(instance);
				game= GameObject.Find ("Main Camera").gameObject.GetComponent<StartSnake> ();
				game.score+=1;
				game.foodleft-=1;
				//Debug.Log (game.foodleft);
					
				//transform.position=new Vector3((other.transform.position.x-.5f), transform.position.y,0);  
				//Destroy (gameObject);
			}
			if (other.name=="Segment(Clone)"){
				//Destroy (other.gameObject);
				Destroy (this.gameObject);
				//game.score-=1;
				Debug.Log ("hit");
			}
			if (other.name == "Wall(Clone)") {
				/* stop movememt entirely 
				 * or end game if too difficult
				 */


			}
		}
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
	
		int i = 1;
		SnakeMovement piece;
		while (i<list.Count){
			piece = list[i-1].gameObject.GetComponent<SnakeMovement> ();
			list[i].transform.position = piece.lastposition;
			piece.lastposition = piece.transform.position;

			//piece=null;
			//Debug.Log(i);
			i++;
		}
	}

}
