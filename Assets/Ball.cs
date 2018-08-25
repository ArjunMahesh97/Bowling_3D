using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody rigidBody;
	private AudioSource ballSound;
	public Vector3 launchVelocity;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		ballSound = GetComponent<AudioSource> ();

		Launch ();
	}

	public void Launch ()
	{
		rigidBody.velocity = launchVelocity;
		ballSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
