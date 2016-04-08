using UnityEngine;
using System.Collections;

public class RedCellScript : DragAndDrop {

    private Color startColor;
    private Vector3 pos;

    void OnMouseEnter() {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }
}
