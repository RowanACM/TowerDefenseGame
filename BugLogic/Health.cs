using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health;
	private bool inv; // invincibility frames active?
	// Use this for initialization
	void Start () {
		inv = false;
	}

	void OnCollisionStay(Collision collision) {
		if (collision.gameObject.GetComponent ("Damage") != null && !inv) {
			Damage damageComponent = collision.gameObject.GetComponent ("Damage") as Damage;
			if (this.gameObject.GetComponent("Armor") != null) {
				Armor armorComponent = this.gameObject.GetComponent ("Armor") as Armor;
				this.health -= (damageComponent.damage - armorComponent.armor < 0)? 0: (damageComponent.damage - armorComponent.armor);
			} else {
				this.health -= damageComponent.damage;
			}
			StartCoroutine ("DamageCoroutine");
		}
	}

	IEnumerator DamageCoroutine() {
		checkHealth ();
		inv = true;
		yield return new WaitForSeconds (0.5f);
		inv = false;
	}
		
	public void checkHealth() {
		if (this.health <= 0) {
			this.health = 0;
			// play death animation
			Destroy (this.gameObject);
		}
	}
}
