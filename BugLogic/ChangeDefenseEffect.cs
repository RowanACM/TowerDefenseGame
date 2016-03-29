using UnityEngine;
using System.Collections;

public class ChangeDefenseEffect : Effect {

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
			doEffect (); // doEffect() is here because this effect must modify a value at regular intervals, whereas halving armor is just once
		}
	}

	public override void doEffect() {
		if (gameObject.GetComponent ("Armor") != null) {
			didIt = true;
			Armor armorComponent = gameObject.GetComponent ("Armor") as Armor;
			armorComponent.armor += magnitude;
		}
	}

	public override void reverseEffect() {
		if (didIt) {
			Armor armorComponent = gameObject.GetComponent ("Armor") as Armor;
			armorComponent.armor -= magnitude;
		}
		Destroy (this);
	}
}
