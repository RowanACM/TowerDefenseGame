using UnityEngine;
using System.Collections;

public class SlowEffect : Effect {

	// Use this for initialization
	void Start () {
		didIt = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.time -= Time.deltaTime;
		if (this.time <= 0) {
			reverseEffect ();
		} else if (!didIt) {
			doEffect ();
		}
	}

	public override void doEffect () {
		if (gameObject.GetComponent ("Movement") != null) {
			didIt = true;
			Movement movementComponent = gameObject.GetComponent ("Movement") as Movement;
			movementComponent.movementSpeed = movementComponent.movementSpeed / magnitude;
		}
	}

	public override void reverseEffect () {
		if (didIt) {
			Movement movementComponent = gameObject.GetComponent ("Movement") as Movement;
			movementComponent.movementSpeed = movementComponent.movementSpeed * magnitude;
		}
		Destroy (this);
	}
}
