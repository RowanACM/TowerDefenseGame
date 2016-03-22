using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnThing;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawn()
	{
		Instantiate (spawnThing);
	}
}
