using UnityEngine;
using System.Collections;

public class Fan : Tower {

    private float aoeRange = 2.0f;
    
    public Fan()
    {
	damage = .5f;
        cooldown = .1f;
        range = 50f;
    }
    
       void Update()
    {
        if (Time.time - lastFire > cooldown) // attack process;
        {
            Detect();
            if (target != null)
            {
                attackBugsAroundTarget(target);// aoe attack.
                Fire(target);

            }
        }

    }

    public void attackBugsAroundTarget(Transform target)
    {
        Bug[] bugs = FindObjectsOfType<Bug>();
        foreach(Bug b in bugs)
        {
            float distance = Vector3.Distance(target.position, b.transform.position);
            if(distance <= aoeRange)
            {
                GameObject Bul = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;    //Instatiate the bullet
                Bul.GetComponent<Bullet>().Targeting(transform, b.transform, damage);   //get components of Bullet, then pass in the tower, target ,tower damge;
            }
        }
    }

}
