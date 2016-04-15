using UnityEngine;
using System.Collections;

public class RedCellScript : DragAndDrop {

    private Color startColor;

    void OnMouseEnter() {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseUp() {
        Destroy(item);
        item = null;
        print("destroyed");
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }
}
