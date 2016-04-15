using UnityEngine;
using System.Collections;

public class Setter : MonoBehaviour {

    public Store store;
    public Transform greenCell;
    public Transform obj;
    private bool set;
    
    void Update() {
        if (set) {
            Destroy(gameObject);
            Instantiate(obj, greenCell.position, Quaternion.identity);
            print("green");
        }
        if (!set) {
            Destroy(gameObject);
            print("destroy");
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "GreenCell") {
            set = true;
        }
        else {
            set = false;
        }
    }

}

