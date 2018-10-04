using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
	public Text standingDisplay;

	public bool BallOutOfPlay = false;
	private int lastStandingCount = -1;
	private int lastSettledCount=10;
	private float lastChangeTime; 

	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (BallOutOfPlay) {
			CheckStanding ();
			standingDisplay.color = Color.yellow;

		}
		
	}

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.name == "Ball") {
			BallOutOfPlay = true;
		}
	}

	void CheckStanding(){
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 5f;
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsHaveSettled ();
		}	
	}

	void PinsHaveSettled(){
		int pinFall = lastSettledCount - CountStanding ();
		lastSettledCount = CountStanding ();

		gameManager.Bowl (pinFall);

		standingDisplay.color = Color.green;
		lastStandingCount = -1;
		BallOutOfPlay = false;
	}

	int CountStanding(){
		int standing = 0;
		foreach (Pins pin in GameObject.FindObjectsOfType<Pins>()) {
			if (pin.IsStanding ())
				standing++;
		} 
		return standing;
	}

	public void Reset(){
		lastSettledCount = 10;
	}
}
