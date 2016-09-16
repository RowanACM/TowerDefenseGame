using UnityEngine;
using System.Collections;

public class CellScript : MonoBehaviour {

	private Color startColor;
	public GameObject item;
	public bool highlighted;
	public float opacity;
	public bool closed;
	private float posLockSpeed;
	private float posLockAccel;

	void Start() {
		startColor = GetComponent<Renderer>().material.color;
	}

	public void setPosLockAttributes(float speed, float accel)
	{
		this.posLockSpeed = speed;
		this.posLockAccel = accel;
	}

	void Update()
	{
			Material currMaterial = GetComponent<Renderer> ().material;
			if (item) {
				currMaterial.color = new Color(0.0f,0.0f,0.0f,0.0f);
			} else {
				if(!closed){
					currMaterial.color = Color.green;
				} else {
					currMaterial.color = Color.red;
				}
				currMaterial.color = new Color (currMaterial.color.r, currMaterial.color.g, currMaterial.color.b, opacity);
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

	public void SetPreviewPosition(GameObject item)
	{
		item.GetComponent<MoveToTargetComponent>().startMove(posLockSpeed, posLockAccel, this.transform.position);
	}

	public void AddItem(GameObject item)
	{
		this.item = item;
		if(item)
			SetPreviewPosition (item);
	}
}
