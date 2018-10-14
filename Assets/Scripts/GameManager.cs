﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private List<int> bowls = new List<int>();

	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;
	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		ball = GameObject.FindObjectOfType<Ball> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bowl(int pinFall){
		try{
			bowls.Add (pinFall);
			ball.Reset ();
			ActionMaster.Action nextAction = ActionMaster.NextAction (bowls);
			pinSetter.PerformAction (nextAction);
		}catch{
			Debug.LogWarning("Error");
		}
		try{
			scoreDisplay.FillRollCards (bowls);
		}catch{
			Debug.LogWarning("fillrollcards failed");
		}


	}
}
