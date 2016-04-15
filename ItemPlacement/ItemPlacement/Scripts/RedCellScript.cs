using UnityEngine;
using System.Collections;

public class RedCellScript : DragAndDrop {

    private Color startColor;
    public Transform gCell;
    public Transform redCell;

    void OnMouseEnter() {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }

    void Return() {
        Instantiate(gCell, redCell.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
