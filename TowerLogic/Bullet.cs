/*using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Transform Tower;
    public Transform Target;
    public float damage;
    public float ApproachingTarget = 1.0f;
    public float transition = 0.0f;
    public bool fired = false;
    float range = 0;

	
	// Update is called once per frame
	void Update () {

        if (!fired)
        {
            return;
        }

       transition += (Time.deltaTime / ApproachingTarget)*10;   // speed of bullet

        CheckHitTarget();

        transform.position = Vector3.Lerp(Tower.position, Target.position, transition); //update locatoins so it follows

	}

    void CheckHitTarget()
    {
        float distance = Vector3.Distance(transform.position, Target.position);
        if(distance <= range) // if bullet hits the target;
        {
            DoDamage();
            Destroy(gameObject); //destroy bullet;
        }
    }

    void DoDamage()  // Need to work with bug logic;
    {

    }

    public void Targeting(Transform tower, Transform target, float damage) 
    {
        fired = true;
        Tower = tower;
        Target = target;
        this.damage = damage;
    }

}
*/