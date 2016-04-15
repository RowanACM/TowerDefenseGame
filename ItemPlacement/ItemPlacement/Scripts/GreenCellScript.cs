using UnityEngine;
using System.Collections;

public class GreenCellScript : MonoBehaviour {
    private Color startColor;
    public GameObject item;
    public Transform gCell;
    public Transform redCell;
    private DragAndDrop drag;
    

    void OnMouseEnter() {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.green;
    }

    void OnMouseUp() {
        if(drag.available) {
            Instantiate(item, gCell.position, Quaternion.identity);
            Instantiate(redCell, gCell.position, Quaternion.identity);
            Destroy(gameObject);
            drag.available = false;
            print("in");
        }
        print("not in");
    }
    
    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }
}
