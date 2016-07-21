using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragAndDropPurchase : MonoBehaviour {
	
	
	public StoreItem item;
	

	// Use this for initialization
	void Start () {
		GetComponent<Image> ().sprite = item.GetComponent<Item> ().getImage ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//on mouse down, we'll instantiate our object and set it inactive until we drag the mouse off
	public void OnMouseDown()
	{
		StoreItem spawnedItem = Instantiate (item);
		spawnedItem.startPurchaseProcess();
		
	}
}
