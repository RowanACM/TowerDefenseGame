using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
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
	
	public void setColor(Color newColor)
	{
		GetComponent<ParticleSystem>().startColor = newColor;
	}

	public bool isOutlineEnabled()
	{
		return outlineEnabled;
	}

	public void Enable()
	{
		
		GetComponent<ParticleSystem> ().Play ();
		
		outlineEnabled = true;
	}


	public void Disable()
	{
		
		GetComponent<ParticleSystem> ().Pause ();
		GetComponent<ParticleSystem> ().Clear ();
		
		outlineEnabled = false;
	}
}
