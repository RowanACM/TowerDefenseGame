using UnityEngine;
using System.Collections;

public class MoveToTargetComponent : MonoBehaviour {
	
	Vector3 targetPosition;
	float acceleration;
	float maxSpeed;
	float currentSpeed;
	float distanceThreshold;
	bool currentlyMoving;
	
	// Use this for initialization
	void Start () {
		currentlyMoving = false;
	}
	
	//use this to move to a static position
	public void startMove(float maxSpeed, float acceleration, Vector3 targetPosition)
	{
		this.maxSpeed = maxSpeed;
		this.currentSpeed = 0.0f;
		this.acceleration = acceleration;
		this.targetPosition = targetPosition;
		distanceThreshold = 0.5f;
		currentlyMoving = true;
	}
	
	private void endMove(){
		this.transform.position = targetPosition;
		currentlyMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentlyMoving) {
			Vector3 difference = targetPosition - this.transform.position;
			float distance = difference.magnitude;
			if(distance > distanceThreshold) {
				//find the amount of time it would take to decelerate
				float estimatedTime = currentSpeed / acceleration;
				//how far would we travel in this time?
				float stoppingDistance = (currentSpeed * estimatedTime) / 2;
				//if our stopping distance is greater than or equal to the distance we have left, decelerate
				if(stoppingDistance >= distance) {
					currentSpeed -= Time.deltaTime * acceleration;
					if(currentSpeed < 0.0f)
						endMove();
				} else {
					//else, let's check if accelerating at this time step would overshoot us
					float nextSpeed = currentSpeed + Time.deltaTime * acceleration;
					if(nextSpeed > maxSpeed)
						nextSpeed = maxSpeed;
					estimatedTime = nextSpeed / acceleration;
					stoppingDistance = (nextSpeed * estimatedTime) / 2;
					//will we overshoot if we accelerate?
					if(stoppingDistance <= distance) {
						currentSpeed += Time.deltaTime * acceleration;
						//clamp the currentSpeed to be <= maxSpeed
						if(currentSpeed > maxSpeed)
							currentSpeed = maxSpeed;
					}	
				}
				
				float currOffset = currentSpeed * Time.deltaTime;
				if(currOffset > distance)
					endMove();
				else
					this.transform.position += currOffset * difference.normalized;
			} else {
				endMove();
			}
		}
	}
}
