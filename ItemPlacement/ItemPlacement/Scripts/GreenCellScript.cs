using UnityEngine;
using System.Collections;

public class GreenCellScript : MonoBehaviour {

    private Color startColor;

	void OnMouseEnter() {
        startColor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.green;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = startColor;
    }
}
