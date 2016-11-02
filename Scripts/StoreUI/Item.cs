using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public string itemName;
	public Sprite image;
	public int price;
	// Use this for initialization
	void Start () {
	
	}

	public int GetPrice()
	{
		return price;
	}

	public string getName()
	{
		return name;
	}

	public Sprite getImage()
	{
		return image;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
