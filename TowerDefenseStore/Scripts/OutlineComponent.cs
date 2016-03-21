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
			SetOutlineColor (color);
			SetOutlineWidth (outlineWidth);
			outlineEnabled = true;
		} else {
			SetOutlineWidth (0.0f);
			outlineEnabled = false;
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
		SetOutlineColor (color);
		SetOutlineWidth (outlineWidth);
		outlineEnabled = true;
	}

	private void SetOutlineColor(Color color)
	{
		GetComponent<MeshRenderer> ().material.SetColor ("_OutColor", color);
	}
	private void SetOutlineWidth(float width)
	{
		GetComponent<MeshRenderer> ().material.SetFloat ("_Outline", width);
	}

	public void Disable()
	{
		SetOutlineWidth (0.0f);
		outlineEnabled = false;
	}
}
