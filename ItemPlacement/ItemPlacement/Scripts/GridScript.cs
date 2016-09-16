using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {
    
    public GameObject gridCell;
	public Vector3 Size;
	public Vector2 spacing;
	public string SecretCode;
	public float posLockAccel = 20.0f;
	public float posLockSpeed = 1.0f;
    int c = 0;

	void Start() {
        CreateGrid();
    }

	void CreateGrid() {
		
		Vector2 bounds = new Vector3(Size.x/2, Size.z/2);
	    for(int x = 0; x < Size.x; x++) {
            for (int z = 0; z < Size.z; z++) {
                c++;
                string part = SecretCode.Substring(c, 1);
	            GameObject cell = (GameObject)Instantiate(gridCell, new Vector3(spacing.x*(((float)x) - bounds.x + 0.5f) + this.transform.position.x, this.transform.position.y, spacing.y*(((float)z) - bounds.y + 0.5f) + this.transform.position.z), Quaternion.identity);
	            cell.GetComponent<CellScript>().setPosLockAttributes(posLockSpeed, posLockAccel);
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
