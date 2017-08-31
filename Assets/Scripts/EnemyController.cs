using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private string direction;
	public float velocity;
	public GameObject player;
	private PlayerController playerController;


	// Use this for initialization
	void Start () {
		direction = "right";	
		playerController = player.GetComponent<PlayerController> ();
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
		if (collision.gameObject.CompareTag ("Building")) {
			changeDirection ();
		}

		if (collision.gameObject.CompareTag ("Player")) {
			playerController.removeLife ();
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
