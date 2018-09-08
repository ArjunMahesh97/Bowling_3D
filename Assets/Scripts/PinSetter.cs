using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {
	private bool ballEnteredBox = false;
	private float lastChangeTime; 
	private Ball ball;

	public int lastStandingCount = -1;
	public Text standingDisplay;
	//public float distanceToraise = 40f;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			CheckStanding ();
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
		ball.Reset ();
		lastStandingCount = -1;
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding(){
		int standing = 0;
		foreach (Pins pin in GameObject.FindObjectsOfType<Pins>()) {
			if (pin.IsStanding ())
				standing++;
		} 
		return standing;
	}

	public void RaisePins(){
		foreach (Pins pin in GameObject.FindObjectsOfType<Pins>()) {
			pin.Raise ();
		}
	}

	public void LowerPins(){
		foreach (Pins pin in GameObject.FindObjectsOfType<Pins>()) {
			pin.Lower ();
		}		
	}

	public void RenewPins(){

	}

	void OnTriggerEnter(Collider collider){
		GameObject thingHit = collider.gameObject;

		if (thingHit.GetComponent<Ball> ()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}
	}

	void OnTriggerExit(Collider collider){
		GameObject thing = collider.gameObject;

		if (thing.GetComponent<Pins> ()) {
			Destroy(thing );
		}
	}
}

