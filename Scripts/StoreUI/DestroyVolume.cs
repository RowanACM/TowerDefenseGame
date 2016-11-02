using UnityEngine;
using System.Collections;

public class DestroyVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col) {
		print ("triggerred!!!1");
		if(col.gameObject.GetComponent<StoreItem>()){
			print ("destroy thisssss");
			Destroy(col.gameObject);
		}
	}
}
