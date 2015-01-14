using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public bool MoveWithArrowKeys = false;
	
	public float speed = 3f;

	private Ball ball;
	
	public float padding = 1;
	
	private float xmax = -5;
	private float xmin = 5;
	
	void Start(){
	ball = GameObject.FindObjectOfType<Ball>();
		GetCamera();
	}
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			Movement();
		}else{
			AutoPlay();
		}
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		
		paddlePos.x = Mathf.Clamp(ballPos.x, 0.25f, 16.65f);
		
		this.transform.position = paddlePos;
	}
	
	void Movement() {
		if(!MoveWithArrowKeys){
		Vector3 mousepos = Input.mousePosition;
		mousepos.z = 1.0f;
		float mouseXPosWorldUnits = Camera.main.ScreenToWorldPoint(mousepos).x;
	
		
		// Creates the new position for the paddle
		Vector3 paddlePos = new Vector3 (
		Mathf.Clamp(mouseXPosWorldUnits, 0.25f, 16.65f), // limits from visual inpection
		this.transform.position.y,// keep old y pos
		this.transform.position.z // keep old z pos
		);
		
		this.transform.position = paddlePos;
		}else{
		if(MoveWithArrowKeys){
			if(Input.GetKey(KeyCode.RightArrow)){
				Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
				paddlePos.x++;
				
				this.transform.position = paddlePos;
			}else{
				if(Input.GetKey(KeyCode.LeftArrow)){
					Vector3 paddlePos = new Vector2 (0.5f, 0f);
					paddlePos.x--;
					
					this.transform.position = paddlePos;
					}
				}
			}
		}
	}
	
	public void GetCamera(){
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		xmin = camera.ViewportToWorldPoint(new Vector3 (0,0, distance)).x + padding;
		xmax = camera.ViewportToWorldPoint(new Vector3 (1,1, distance)).x - padding;
	}
	
	
	public void MoveWithKeys(){
		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position = new Vector3(Mathf.Clamp(transform.position.x + speed * Time.deltaTime, xmin, xmax)
			                                 ,transform.position.y, 
			                                 transform.position.z
			                                 );
		}else if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x -speed * Time.deltaTime, xmin, xmax)
			                                  ,transform.position.y, 
			                                  transform.position.z
			                                  );
		}		
	}
}


