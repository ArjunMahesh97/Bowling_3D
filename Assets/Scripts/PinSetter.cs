using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {
	
	private float lastChangeTime; 
	private Ball ball;
	private int lastSettledCount=10;
	private Animator animator;
	private int lastStandingCount = -1;

	public GameObject pinSet;

	public bool BallOutOfPlay = false;
	public Text standingDisplay;
	//public float distanceToraise = 40f;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (BallOutOfPlay) {
			CheckStanding ();
			standingDisplay.color = Color.yellow;

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
		ActionMaster actionMaster = new ActionMaster();

		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		Debug.Log ("Pinfall: " + pinFall + " action: " + action);

		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		}else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			lastSettledCount=10;
		}else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			lastSettledCount=10;
		}else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Dont know");
		}

		standingDisplay.color = Color.green;
		ball.Reset ();
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
		Instantiate (pinSet, new Vector3 (0, 0, 1829), Quaternion.identity);

	}

	/*
	void OnTriggerEnter(Collider collider){
		GameObject thingHit = collider.gameObject;

		if (thingHit.GetComponent<Ball> ()) {
			BallOutOfPlay = true;
			standingDisplay.color = Color.red;
		}
	}
	*/

	void OnTriggerExit(Collider collider){
		GameObject thing = collider.gameObject;

		if (thing.GetComponent<Pins> ()) {
			Destroy(thing );
		}
	}
}

