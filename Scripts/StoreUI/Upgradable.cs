using UnityEngine;
using System.Collections;

public class Upgradable : MonoBehaviour {

	public int maxLevel = 3;
	[Range(1,3)]
	public int level;
	public int[] upgradeCosts;
	public int[] sellValues;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getUpgradeCost()
	{
		if (level < maxLevel)
			return upgradeCosts [level - 1];
		else
			return -1;
	}

	public bool isUpgradable()
	{
		return level < maxLevel;
	}

	public int getSellValue()
	{
		return sellValues [level - 1];
	}

	public void Upgrade() {
		level++;
	}
}
