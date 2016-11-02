using UnityEngine;
using System.Collections;

public class PathedMovement : Movement {

	public GameObject point;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (this.point != null) {
			movementTowardsPoint ();
		} else {
			Destroy (gameObject); // maybe try and find new target?
		}
	}

	private void setPoint () {
		if (this.point.GetComponent ("NextPoint") != null) { // maybe move towards something besides a point?
			NextPoint currentNextPoint = this.point.GetComponent ("NextPoint") as NextPoint;
			if (currentNextPoint.nextPoint == null) {
				Destroy (gameObject);
			}
			this.point = currentNextPoint.nextPoint;
		} else {
			Destroy (gameObject);
		}
	}

	private void movementTowardsPoint () {
		transform.position = Vector3.MoveTowards (transform.position, this.point.transform.position, this.movementSpeed * Time.deltaTime);
		Quaternion targetingRotation = Quaternion.LookRotation (this.point.transform.position - transform.position);
		transform.rotation = Quaternion.Lerp (this.transform.rotation, targetingRotation, Time.deltaTime);
		if (transform.position.Equals(this.point.transform.position)) {
			setPoint ();
		}
	}
}
