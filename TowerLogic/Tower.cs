﻿using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
    public GameObject bullet;

    float range = 10.0f;
    int damage; // the actual dealing damage is in the Bullet class;
    float cooldown = .2f;
    float lastFire = 0.0f;
    Transform target = null;
    float health; // NEED to be determine base on boss bugs attacks.
    int cost; // Not sure if we need this here;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    /*
            We might want the turret to rotate base on the direction it's shooting at, it's not hard to do, but since we have multiple 
        models, some of them would only rotate a partial of the model, so it is not in this basic tower logic code.
    */
	void Update () {
        if(Time.time - lastFire > cooldown) // attack process;
        {
            Detect();
            if (target != null)
            {
                Fire(target);
            }
        }
        
	}

    protected virtual void Fire(Transform t)
    {
        lastFire = Time.time;   //set lastFire to the time it fire.

        GameObject Bul = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;    //Instatiate the bullet
        Bul.GetComponent<Bullet>().Targeting(transform,t,damage);   //get components of Bullet, then pass in the tower, target ,tower damge;
        target = null;      //reset target.
    }


    void Detect()
    {
        Bug[] bugs = FindObjectsOfType<Bug>();  // Get all the bugs in the scene;
        Transform nearestBug = null;
        float distance = Mathf.Infinity;    

        foreach(Bug b in bugs)
        {
            float dist = Vector3.Distance(transform.position, b.transform.position);    //get the distance of the bug;
            if(nearestBug == null || dist < distance)     //if there's no nearestBug yet, or the bug is closer than the last setted distance;
            {
                nearestBug = b.transform;
                distance = dist;
            }
        }

        if(distance <= range)       // if the nearestBug is in tower attack range, set it to the target;
        {
            target = nearestBug;
        }
    }

    void Upgrade()// Not settle till later.
    {

    }
}