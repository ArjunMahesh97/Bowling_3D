using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();
		
	}

	int CountStanding(){
		int standing = 0;
		foreach (Pins pin in GameObject.FindObjectsOfType<Pins>()) {
			if (pin.IsStanding ())
				standing++;
		} 
		return standing;
	}
}
