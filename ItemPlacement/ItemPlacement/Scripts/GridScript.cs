using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {
    
    public GameObject gridCell;
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
				GameObject cell = (GameObject)Instantiate(gridCell, new Vector3(6*x-28, 1, 6*z-30), Quaternion.identity);
                if(part.Equals("1")) {
					cell.GetComponent<CellScript>().setClosed (false);
                }
                else {
					cell.GetComponent<CellScript>().setClosed(true);
                }
            }
        }
    }
}
