using UnityEngine;
using System.Collections;

public class PoisonEffect : Effect {

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
		StartCoroutine ("PoisonCoroutine");
	}

	IEnumerator PoisonCoroutine() {
		if (this.gameObject.GetComponent ("Health") != null) {
			Health healthComponent = this.gameObject.GetComponent ("Health") as Health;
			healthComponent.health -= this.magnitude;
			healthComponent.checkHealth ();
			didIt = true;
			yield return new WaitForSeconds (0.5f); // time between occurances of damage is currently half a second
			didIt = false;
		}
	}

	public override void reverseEffect() {
		// poison damage is not undone when it wears off
		Destroy (this); // destroy this component
	}
}
