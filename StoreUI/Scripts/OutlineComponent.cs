using UnityEngine;
using System.Collections;

public class OutlineComponent : MonoBehaviour {

	public float outlineWidth;
	private bool outlineEnabled;
	public bool startEnabled;
	public Color color;

	// Use this for initialization
	void Start () {
		if (startEnabled) {
			Enable ();
		} else {
			Disable ();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool isOutlineEnabled()
	{
		return outlineEnabled;
	}

	public void Enable()
	{
		if (GetComponent<ParticleSystem> ()) {
			GetComponent<ParticleSystem> ().Play ();
		}
		outlineEnabled = true;
	}


	public void Disable()
	{
		if (GetComponent<ParticleSystem> ()) {
			GetComponent<ParticleSystem> ().Pause ();
			GetComponent<ParticleSystem> ().Clear ();
		}
		outlineEnabled = false;
	}
}
