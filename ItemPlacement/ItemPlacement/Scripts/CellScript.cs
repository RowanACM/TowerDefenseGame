using UnityEngine;
using System.Collections;

public class CellScript : MonoBehaviour {

	private Color startColor;
	public GameObject item;
	public bool closed;

	void OnMouseEnter() {
		startColor = GetComponent<Renderer>().material.color;
	}

	void OnMouseOver(){
		if (IsOpen()) {
			GetComponent<Renderer> ().material.color = Color.green;
		} else {
			GetComponent<Renderer>().material.color = Color.red;
		}
	}

	public void setClosed(bool closed){
		this.closed = closed;
	}

	void OnMouseExit() {
		GetComponent<Renderer>().material.color = startColor;
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
		if (this.item)
			Destroy (this.item);
		this.item = item;
		LockPreviewPosition (item);
	}
}
