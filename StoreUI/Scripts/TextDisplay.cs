using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextDisplay : MonoBehaviour {
	
	
	public TextMesh entryTemplate;
	List<GameObject> entries;
	List<int> priorities;
	
	// Use this for initialization
	void Start () {
		entries = new List<GameObject>();
		priorities = new List<int>();
	}
	
	//Returns the TextMesh component of the gameObject that was added
	public TextMesh Add(int priority)
	{
		int index = 0;
		while(index < entries.Count)
		{
			if(priority < priorities[index]) {
				break;
			}
			else{
				index++;
			}
		}
		print("creating text!");
		GameObject newEntry = Instantiate(entryTemplate).gameObject;
		print("created the text! at position: " + newEntry.transform.position);
		newEntry.transform.parent = this.transform;
		print("parented!!");
		addAtIndex(index, priority, newEntry);
		return newEntry.GetComponent<TextMesh>();
	}
	
	public void Remove(TextMesh entry) {
		if(entries.Count > 0) {
			int index = 0;
			while(index < entries.Count)
			{
				print(index + " index ");
				if(entries[index] == entry.gameObject) {
					break;
				} else {
					index++;
				}
			}
			if(index < entries.Count) {
				GameObject removedEntry = shiftDownAtIndex(index);
				Destroy(removedEntry);
			}
		}
	}
	
	protected void addAtIndex(int index, int priority, GameObject newEntry)
	{
		if(index == entries.Count) {
			entries.Add(newEntry);
			priorities.Add(priority);
		} else {
			shiftUpAtIndex(index);
			entries[index] = newEntry;
			priorities[index] = priority;
		}
		newEntry.transform.localPosition = getEntryPosition(index);
	}
	
	protected Vector3 getEntryPosition(int index)
	{
		return index * new Vector3(0.0f,(entryTemplate.fontSize + entryTemplate.lineSpacing) * entryTemplate.characterSize / 10.0f,0.0f);
	}
	
	protected GameObject shiftDownAtIndex(int index)
	{
		if(index < 0)
			index = 0;
		print(entries.Count);
		print(index);
		GameObject removedEntry = entries[index];
		for(int i = index; i < entries.Count - 1; i++)
		{
			entries[i] = entries[i + 1];
			entries[i].transform.localPosition = getEntryPosition(i);
		}
		if(entries.Count > 0)
			entries.RemoveAt(entries.Count - 1);
		return removedEntry;
	}
	
	protected void shiftUpAtIndex(int index)
	{
		if(index < 0)
			index = 0;
		for(int i = entries.Count; i > index; i--)
		{
			if(i == entries.Count) {
				entries.Add(entries[i - 1]);
			}
			else {
				entries[i] = entries[i - 1];
			}
			entries[i].transform.localPosition = getEntryPosition(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
