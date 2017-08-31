using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private string direction;
	public float velocity;

	// Use this for initialization
	void Start () {
		direction = "right";	
	}
	
	// Update is called once per frame
	void Update () {
		if (direction == "right") {
			transform.position = 
				new Vector3(
					transform.position.x + velocity, 
					transform.position.y, 
					transform.position.z
				);
		}

		if (direction == "left") {
			transform.position = 
				new Vector3(
					transform.position.x - velocity, 
					transform.position.y, 
					transform.position.z
				);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("Enemy Collision!!");

		if (collision.gameObject.CompareTag ("Building")) {
			Debug.Log ("Building!!");
			changeDirection ();
		}
	}

	void changeDirection() {
		if (direction == "right") {
			direction = "left";
		} else {
			direction = "right";
		}
	}
}
