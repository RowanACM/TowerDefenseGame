using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class OutlineComponent : MonoBehaviour {

	public float outlineWidth;
	private bool outlineEnabled;
	public bool startEnabled;
	private bool particlesOn;
	public Color color;

	// Use this for initialization
	void Start () {
		setParticles(true);
		if (startEnabled) {
			Enable ();

		} else {
			Disable ();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void setParticles(bool on)
	{
		if(on) {
			if(isOutlineEnabled())
				GetComponent<ParticleSystem> ().Play ();
			particlesOn = true;
			
		} else {
			if(isOutlineEnabled()) {
				GetComponent<ParticleSystem> ().Pause ();
				GetComponent<ParticleSystem> ().Clear ();
			}
			particlesOn = false;
				
		}
			
	}
	
	public void setColor(Color newColor)
	{
		GetComponent<ParticleSystem>().startColor = newColor;
		
		Material currMat = GetComponentInChildren<MeshRenderer>().material;
		newColor.a = currMat.GetColor("_OutlineColor").a;
		currMat.SetColor("_OutlineColor", newColor);
	}

	public bool isOutlineEnabled()
	{
		return outlineEnabled;
	}
	
	public void makeOpaque()
	{
		Material currMat = GetComponentInChildren<MeshRenderer>().material;
		Color currColor = currMat.GetColor("_Color");
		currColor.a = 1.0f;
		currMat.SetColor("_Color", currColor);
		
		Color currOutlineColor = currMat.GetColor("_OutlineColor");
		currOutlineColor.a = 0.2f;
		currMat.SetColor("_OutlineColor", currOutlineColor);
	}

	public void Enable()
	{
		if(particlesOn)
			GetComponent<ParticleSystem> ().Play ();
		
		Material currMat = GetComponentInChildren<MeshRenderer>().material;
		Color currColor = currMat.GetColor("_Color");
		currColor.a = 0.3f;
		currMat.SetColor("_Color", currColor);
		
		Color currOutlineColor = currMat.GetColor("_OutlineColor");
		currOutlineColor.a = 0.5f;
		currMat.SetColor("_OutlineColor", currOutlineColor);
		
		outlineEnabled = true;
	}


	public void Disable()
	{
		if(particlesOn) {
			GetComponent<ParticleSystem> ().Pause ();
			GetComponent<ParticleSystem> ().Clear ();
		}
		Material currMat = GetComponentInChildren<MeshRenderer>().material;
		Color currColor = currMat.GetColor("_Color");
		currColor.a = 1.0f;
		currMat.SetColor("_Color", currColor);
		
		Color currOutlineColor = currMat.GetColor("_OutlineColor");
		currOutlineColor.a = 0.0f;
		currMat.SetColor("_OutlineColor", currOutlineColor);
		
		outlineEnabled = false;
	}
}
