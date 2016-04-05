using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Transform Tower;
    public Transform Target;
    public int damage;
    public float ApproachingTarget = 1.0f;
    public float transition = 0.0f;
    public bool fired = false;
    float range = 5f;

	
	// Update is called once per frame
	void Update () {

        if (!fired)
        {
            return;
        }

		if (Target == null) { // target has been eliminated
			Destroy(gameObject); // remove this bullet from the scene
		}

       transition += (Time.deltaTime / ApproachingTarget)*10;   // speed of bullet

        CheckHitTarget();
		if (Target != null) {
			transform.position = Vector3.Lerp (Tower.position, Target.position, transition); //update locatoins so it follows
		}
	}

    void CheckHitTarget()
    {
		if (Target != null) {
			float distance = Vector3.Distance (transform.position, Target.position);
			if (distance <= range) { // if bullet hits the target;
				DoDamage (Target, damage);
			}
		}
    }

    void DoDamage(Transform target, int damage)  // Need to work with bug logic;
    {
		Health tHealth = target.GetComponent ("Health") as Health;

		if (target.GetComponent("Armor") != null) {
			Armor armorComponent = target.GetComponent ("Armor") as Armor;
			tHealth.health -= (damage - armorComponent.armor < 0)? 0: (damage - armorComponent.armor);
		} else {
			tHealth.health -= damage;
		}

		tHealth.checkHealth ();
		Destroy(gameObject); //destroy bullet;
    }

    public void Targeting(Transform tower, Transform target, int damage) 
    {
        fired = true;
        Tower = tower;
        Target = target;
        this.damage = damage;
    }

}
