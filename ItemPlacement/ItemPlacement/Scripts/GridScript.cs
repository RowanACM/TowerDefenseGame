using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {

    public List<Transform> cells = new List<Transform>();
    public Transform GreenCell;
    public Transform RedCell;
    public Vector3 Size;
    public string SecretCode;
    int c = 0;

	void Start() {
        CreateGrid();
    }

    void CreateGrid() {
        for(int x = 0; x < Size.x; x++) {
            for (int z = 0; z < Size.z; z++) {
                c++;
                string part = SecretCode.Substring(c, 1);
                if(part.Equals("1")) {
                    Instantiate(GreenCell, new Vector3(x, 0, z), Quaternion.identity);
                }
                else {
                    Instantiate(RedCell, new Vector3(x, 0, z), Quaternion.identity);
                }
            }
        }
    }
}
