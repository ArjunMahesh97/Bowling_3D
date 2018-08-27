 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public bool inPlay = false;
	private Rigidbody rigidBody;
	private AudioSource ballSound;
	public Vector3 launchVelocity;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		ballSound = GetComponent<AudioSource> ();
		rigidBody.useGravity = false;
	}

	public void Launch (Vector3 vel)
	{
		inPlay = true;
		rigidBody.velocity = vel;
		rigidBody.useGravity = true;
		ballSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
