using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public GameObject player;
	private PlayerController playerController;
	public Text surveysText;
	public Text timeText;
	public Text pointsText;
	public Text lifesText;

	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		surveysText.text = playerController.numOfSurveysCollected.ToString("000");
		timeText.text = playerController.timeRemaining.ToString("000");
		pointsText.text = playerController.points.ToString("000");
		lifesText.text = playerController.lifesRemaining.ToString("000");
	}
}
