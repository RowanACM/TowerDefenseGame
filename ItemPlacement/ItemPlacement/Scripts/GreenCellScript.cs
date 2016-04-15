using UnityEngine;
using System.Collections;

public class GreenCellScript : DragAndDrop {

    private Color startColor;
    public CursorMode cursor = CursorMode.Auto;

    void OnMouseEnter() {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.green;
        Cursor.SetCursor(null, transform.position, cursor);
    }

    void OnMouseUp() {
        item.transform.Translate(transform.position);
    }
    
    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }
}
