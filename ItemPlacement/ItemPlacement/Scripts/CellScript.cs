using UnityEngine;
using System.Collections;

public class CellScript : MonoBehaviour {

	private Color startColor;
	public GameObject item;
	public bool highlighted;
	private float opacity;
	public bool closed;

	void Start() {
		startColor = GetComponent<Renderer>().material.color;
	}

	void Update()
	{
		if (highlighted) {
			Material currMaterial = GetComponent<Renderer> ().material;
			if (IsOpen ()) {
				currMaterial.color = Color.green;
			} else {
				currMaterial.color = Color.red;
			}
			currMaterial.color = new Color (currMaterial.color.r, currMaterial.color.g, currMaterial.color.b, opacity);
			highlighted = false;
		} else {
			GetComponent<Renderer>().material.color = startColor;
		}
	}

	public void highlight(float opacity)
	{
		this.opacity = opacity;
		highlighted = true;
	}

	public void setClosed(bool closed){
		this.closed = closed;
	}

	public bool IsOpen(){
		return item == null && !closed;
	}

	public Transform GetPreviewPosition(){
		return this.transform;
	}

	public void LockPreviewPosition(GameObject item)
	{
		item.transform.position = this.transform.position;
	}

	public void AddItem(GameObject item)
	{
		this.item = item;
		if(item)
			LockPreviewPosition (item);
	}
}
