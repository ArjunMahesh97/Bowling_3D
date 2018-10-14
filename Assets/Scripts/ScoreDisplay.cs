using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillRolls(List<int> rolls){
		
	}

	public void FillFrames(List<int> frames){
		for (int i = 0; i < frames.Count; i++) {
			frameTexts [i].text = frames [i].ToString ();
		}
	}

	static string FormatRolls(List<int> rolls){
		
	}
}
