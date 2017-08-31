using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private string direction;
	private Rigidbody2D body;
	public float velocity;
	public float jumpingImpulse;
	private bool walking;
	private bool idle;
	private bool jumping;
	private bool grounded;
	private BoxCollider2D collider;
	public int numOfSurveysCollected;
	public int timeRemaining;
	public int points;
	public int lifesRemaining;

	// Use this for initialization
	void Start () {
		direction = "right";
		body = GetComponent<Rigidbody2D> ();
		collider = GetComponent<BoxCollider2D> ();
		walking = false;
		idle = true;
		jumping = false;
		grounded = false;
		numOfSurveysCollected = 0;
		timeRemaining = 100;
		points = 0;
		lifesRemaining = 3;
	}
	
	// Update is called once per frame
	void Update () {
		// Walking
		walking = false;

		if (Input.GetKey(KeyCode.RightArrow)) {
			direction = "right";
			walking = true;
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			direction = "left";
			walking = true;
		}
			
		if (direction == "right" && walking) {
			transform.position = 
				new Vector3(
					transform.position.x + velocity, 
					transform.position.y, 
					transform.position.z
				);
		}

		if (direction == "left" && walking) {
			transform.position = 
				new Vector3(
					transform.position.x - velocity, 
					transform.position.y, 
					transform.position.z
				);
		}

		// Jumping
		jumping = false;

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded()) {
			jumping = true;
			body.AddForce (new Vector3 (0, jumpingImpulse, 0));
		}
	}

	bool isGrounded() {
		return true;

//		bool result = false;
//
//		RaycastHit hit;
//
//		Vector3 originRay = transform.position + new Vector3(0, -0.8f, 0);
//		Vector3 directionRay = Vector3.down;
//
//		if(Physics.Raycast(originRay, directionRay, out hit, Mathf.Infinity)) { // && hit.transform.tag == "wall"
//			Debug.Log("Hit!!");
//			result = true;
//		}
//		Debug.DrawRay(originRay, directionRay, Color.red);
//
//		Debug.Log ("originRay: " + originRay);
//		Debug.Log ("directionRay: " + directionRay);
//		Debug.Log ("hit: " + hit);
//		Debug.Log ("isGrounded: " + result);
//		return result;
	}

	void OnTriggerEnter2D(Collider2D hit) {
		if (hit.CompareTag ("Survey")) {
			Debug.Log ("Survey!!");
			numOfSurveysCollected += 1;
			Destroy (hit.gameObject);
		}
	}

	public void removeLife() {
		if ( lifesRemaining == 0 ) {
			die ();
		} else {
			lifesRemaining -= 1;
		}
	}

	void die () {
		Debug.Log ("You are dead!!");
		Application.LoadLevel(Application.loadedLevel);
	}
}
