using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {
	public float standingThreshold = 5f;
	public float distanceToraise = 50f;

	private Rigidbody rigidBody;
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//print (name + IsStanding ());
	}

	public bool IsStanding(){
		Vector3 rotationInEulur = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs (270-rotationInEulur.x);
		float tiltInZ = Mathf.Abs (rotationInEulur.z);

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
			return  true;
		else
			return	false;	
	}


	public void Raise(){
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, distanceToraise, 0), Space.World);
		}
	}

	public void Lower(){
		transform.Translate (new Vector3 (0, -distanceToraise, 0), Space.World);
		rigidBody.useGravity = true;
		rigidBody.isKinematic = false;
	}
}
