using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

	public Store store;
	public GameObject item;
    public bool available;

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown() {
        available = true;
        print("clicked");
    }

    /*

	void OnMouseDown () {
		store.purchaseItem = Instantiate (item);
		store.purchaseItem.GetComponent<Collider> ().enabled = false;
		print ("down");
	}

    */
	
	// Update is called once per frame
	void Update () {
		
	}
}
