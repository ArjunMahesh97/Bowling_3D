 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public bool inPlay = false;
	private Rigidbody rigidBody;
	private AudioSource ballSound;
	public Vector3 launchVelocity;
	private Vector3 ballStartPos;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		ballSound = GetComponent<AudioSource> ();
		rigidBody.useGravity = false;
		ballStartPos = transform.position;
	}

	public void Launch (Vector3 vel)
	{
		inPlay = true;
		rigidBody.velocity = vel;
		rigidBody.useGravity = true;
		ballSound.Play ();
	}

	public void Reset(){
		inPlay = false;
		transform.position = ballStartPos;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
