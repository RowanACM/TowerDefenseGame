using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

	public Store store;
	public GameObject item;
    public bool available = false;

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown() {
        available = true;
        print("clicked");
    }

    public bool getAvailable() {
        return available;
    }

    public void changeAvailable(bool avail) {
        available = avail;
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
