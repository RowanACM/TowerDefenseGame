﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(OutlineComponent))]
[RequireComponent(typeof(Item))]
public class StoreItem : MonoBehaviour{
	
	public enum DraggingState {
		DraggingValid, DraggingInvalid, DroppedInvalid, DroppedValid
	}
	
	private CellScript spawnPoint;
	public ParticleSystem destructionEffect;
	private DraggingState state;
	private bool completed;
	private bool beginClick;
	private TextMesh costText;
	private TextMesh fundsAlertText;
	public LayerMask groundLayer;
	
	public bool isPurchased()
	{
		return completed;
	}
	
	float spawnDropRadius = 10.0f;
	
	// Use this for initialization
	void Start () {

		GetComponent<OutlineComponent>().Enable();
		GetComponent<OutlineComponent>().setParticles(false);
		
	}
	
	public void startPurchaseProcess()
	{
		state = DraggingState.DraggingValid;
		completed = false;
		beginClick = false;
		GetComponent<OutlineComponent>().Enable();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		print("hello where art though");
		if(!beginClick) {
			print("going into the switch");
			switch(state)
			{
			
			case DraggingState.DraggingValid: GetComponent<OutlineComponent>().setColor(Color.green);
				break;
			case DraggingState.DraggingInvalid: GetComponent<OutlineComponent>().setColor(Color.red);
				break;
			case DraggingState.DroppedInvalid: GetComponent<OutlineComponent>().setColor(Color.red);
				break;
			case DraggingState.DroppedValid: GetComponent<OutlineComponent>().setColor(Color.white);
				break;
			default:
				break;
			}
		}
	
		Store store = FindObjectOfType<Store>();
		if(!completed) {
			if(costText == null) {
				print ("adding a cost text!");
				costText = GetComponentInChildren<TextDisplay>().Add(0);
				costText.text = "Cost: " + GetComponent<Item>().GetPrice();
			}
			if (store.isPurchaseable (this.GetComponent<Item> ())) {
				if(fundsAlertText) {
					GetComponentInChildren<TextDisplay>().Remove(fundsAlertText);
					fundsAlertText = null;
				}
				if(state == DraggingState.DraggingValid)
					costText.color = Color.green;
				else
					costText.color = Color.red;
			}
			else {
				if (!fundsAlertText) {
					fundsAlertText = GetComponentInChildren<TextDisplay>().Add(1);
					fundsAlertText.text = "INSUFFICIENT FUNDS";
					fundsAlertText.color = Color.red;
				}
				costText.color = Color.red;
			}
		}

		if (state == DraggingState.DraggingValid || state == DraggingState.DraggingInvalid) {
			
			if(Input.GetMouseButtonUp(0))
			{
				DoneDragging();
			}
			else
			{
				//GetComponentInChildren<Collider> ().enabled = false;
				//put placement code here
				//cast a ray to get where mouse is pointing in world
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 100.0f, groundLayer)) { 
					
					//now we'll look for objects within a radius, and find the closest object with CellScript
					CellScript closestCell = null;
					float closestDist = spawnDropRadius + 1.0f;
					Collider[] hitColliders = Physics.OverlapSphere (hit.point, spawnDropRadius);
					for (int i = 0; i < hitColliders.Length; i++) {
						CellScript foundCell = hitColliders [i].GetComponent<CellScript> ();
						if (foundCell != null)
						{
							float dist = (foundCell.transform.position - hit.point).magnitude;
							//foundCell.highlight (1.0f/dist);
							if (dist < closestDist) {
								closestCell = foundCell;
								closestDist = dist;
							}
						}
					}
					//if there was a closest one in radius, we set it as our spawnPoint 
					if (closestCell) {
						if(closestCell != spawnPoint)
						{
							
							Store gameStore = FindObjectOfType<Store> ();
							gameStore.setSelectedItem(null);
							beginClick = false;
							spawnPoint = closestCell;
							spawnPoint.SetPreviewPosition (this.gameObject);
						}
						if(closestCell.IsOpen())
							state = DraggingState.DraggingValid;
						else
							state = DraggingState.DraggingInvalid;
					}
					else
					{
						state = DraggingState.DraggingInvalid;
					}
				}
			}
			//enable collider is cool
			//GetComponentInChildren<Collider> ().enabled = true;
			//could do this on mouse exit, just means we'll only activate our GameObject when dragging
			
			//we'll disable the collider so that the OnMouseOver, etc. methods on the cells work properly through the object
			
			//would like to have some sort of ghosting effect in future, we'll put that in this method
			SetGhost (true);
			
		}
	}
	
	//this method will be a placeholder for the ghost effect to apply to a gameobject
	//while it is being dragged
	void SetGhost(bool ghost)
	{
		
	}
	
	/**
	*	Called when this item was selected as the current Store item but becomes deselected.
	*/
	public void onDeselect() {
		if(state == DraggingState.DroppedValid) {
			GetComponent<OutlineComponent>().Disable();
			GetComponent<OutlineComponent>().setParticles(false);
		}
	}
	
	public void onSelect(){
		GetComponent<OutlineComponent>().Enable();
		GetComponent<OutlineComponent>().setParticles(true);
		GetComponent<OutlineComponent>().makeOpaque();
	}
	
	//placeholder for whatever effect we want to display when an object is destroyed from a failed drag and drop
	void Poof()
	{
		
	}
	
	//on mouse down, we'll instantiate our object and set it inactive until we drag the mouse off
	public void OnMouseDown()
	{
		Store gameStore = FindObjectOfType<Store> ();
		if(state == DraggingState.DroppedValid)
			gameStore.setSelectedItem(this.gameObject);
		else
			gameStore.setSelectedItem(null);
		
		state = DraggingState.DraggingValid;
		if(spawnPoint)
			spawnPoint.AddItem(null);
		GetComponent<OutlineComponent>().Enable();
		
		beginClick = true;
		
	}
	
	public void DoneDragging()
	{
		//we'll find the store object real quick, very nice to use this instead of storing a reference, although technically inefficient.
		//okay with doing this for singleton objects like store
		Store gameStore = FindObjectOfType<Store> ();
		if(completed)
		{
			gameStore.setSelectedItem(this.gameObject);

			if(spawnPoint.IsOpen())
			{
				state = DraggingState.DroppedValid;
				spawnPoint.AddItem(this.gameObject);
			}
			else
				state = DraggingState.DroppedInvalid;
		}
		else
		{
			
			//all the conditions for spawning it, if none are met, we'll just poof the object
			if (spawnPoint == null || !spawnPoint.IsOpen () || !gameStore.purchase(GetComponent<Item>())) {
				//poof method to be filled in with whatever effect we want on poofing the object
				state = DraggingState.DroppedInvalid;
			} else {
				//okay its go time, make it legit, put a ring on it, etc.
				if(costText) {
					GetComponentInChildren<TextDisplay>().Remove(costText);
					costText = null;
				}
				//no more ghost
				SetGhost (false);
				//final method to lock our object into the cell
				spawnPoint.AddItem (this.gameObject);
				gameStore.setSelectedItem (this.gameObject);
				state = DraggingState.DroppedValid;
				completed = true;
			}
		}
		
	}
	
}
