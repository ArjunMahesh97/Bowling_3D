using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	private Animator animator;

	private ActionMaster actionMaster = new ActionMaster();

	public GameObject pinSet;

	private PinCounter pinCounter;


	//public float distanceToraise = 40f;
	// Use this for initialization
	void Start () {
		pinCounter = FindObjectOfType<PinCounter> ();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public void PerformAction(ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Dont know");
		}
	}
}

