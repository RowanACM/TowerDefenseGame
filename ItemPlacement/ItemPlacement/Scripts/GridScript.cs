using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {

    public List<Transform> cells = new List<Transform>(100);
    public Transform GreenCell;
    public Transform RedCell;
    public Vector3 Size;
    public string SecretCode;
    public Transform cell;
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
                    Instantiate(GreenCell, new Vector3(6*x-28, 1, 6*z-30), Quaternion.identity);
                    cells.Add(GreenCell);
                }
                else {
                    Instantiate(RedCell, new Vector3(6*x-28, 1, 6*z-30), Quaternion.identity);
                    cells.Add(RedCell);
                }
            }
        }
    }


}
