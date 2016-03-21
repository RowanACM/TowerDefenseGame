using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

	public Store store;
	public GameObject item;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown () {
		store.purchaseItem = Instantiate (item);
		store.purchaseItem.GetComponent<Collider> ().enabled = false;
		print ("down");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
