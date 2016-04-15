using UnityEngine;
using System.Collections;

public class GreenCellScript : DragAndDrop {
    private Color startColor;
    public GameObject item;
    public Transform gCell;
    public Transform redCell;
    

    void OnMouseEnter() {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.green;
    }

    void OnMouseUp() {
        Instantiate(item, gCell.position, Quaternion.identity);
        Instantiate(redCell, gCell.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }
}
