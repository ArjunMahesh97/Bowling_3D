using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {
	public float standingThreshold = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print (name + IsStanding ());
	}

	public bool IsStanding(){
		Vector3 rotationInEulur = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs (rotationInEulur.x);
		float tiltInZ = Mathf.Abs (rotationInEulur.z);

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
			return  true;
		else
			return	false;	
	}
}
