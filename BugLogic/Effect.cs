using UnityEngine;
using System.Collections;

public abstract class Effect : MonoBehaviour {

	public int magnitude; // the magnitude of the effect (7 poison damage, 7 less defense, etc.)
	public float time; // time it takes for the effect to wear off
	protected bool didIt; // has the effect been used?

	public abstract void doEffect(); // changes affected object based on magnitude
	public abstract void reverseEffect(); // reverses effect and destroys this component
}
