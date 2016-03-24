using UnityEngine;
using System.Collections;

public class RedCellScript : MonoBehaviour {

    private Color startColor;

    void OnMouseEnter() {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }
}
