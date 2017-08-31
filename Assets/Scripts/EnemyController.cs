using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private string direction;
	public float velocity;
	public GameObject player;
	private PlayerController playerController;
	private Animator animator;


	// Use this for initialization
	void Start () {
		direction = "right";	
		playerController = player.GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
		animator.SetBool ("walkingRight", true);
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
			animator.SetBool ("walkingRight", false);
		} else {
			direction = "right";
			animator.SetBool ("walkingRight", true);
		}
	}
}
