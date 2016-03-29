using UnityEngine;
using System.Collections;
using System;

public class SpawnScript : MonoBehaviour {

    public Transform obj;

    public void OnClick() {
        Instantiate(obj, new Vector3(-3, -1, -1), Quaternion.identity);
    }
}