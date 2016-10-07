using UnityEngine;
using System.Collections;

public class ParticleSystemDeath : MonoBehaviour {

	public ParticleSystem destructionEffect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDestroy(){
		Instantiate (destructionEffect, this.transform.position, this.transform.rotation);
	}
}
