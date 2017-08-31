using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	private float offset;

	// Use this for initialization
	void Start () {
		offset = transform.position.x - player.transform.position.x;
	}
	
	// LateUpdate is called after Update each frame
	void LateUpdate () {
		transform.position = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
	}
}
