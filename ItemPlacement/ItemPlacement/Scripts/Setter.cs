using UnityEngine;
using System.Collections;

public class Setter : MonoBehaviour {

    public GameObject greenCell;

    void onMouseUp(Collision col) {
        if(col.gameObject.name == "GreenCell"){
            gameObject.transform.Translate(greenCell.transform.position);
            print("green");
        }
        else {
            Destroy(gameObject);
            print("destroy");
        }
    }


}
