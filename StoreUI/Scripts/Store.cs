using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public int money;
	public GameObject gameCamera;
	public GameObject selectedObject;
	public Text upgradeCost;
	public Text sellAmount;
	public Text moneyAmount;
	public Button upgradeButton;
	public Text selectedItemText;
	public Image selectedItemImage;
	public GameObject selectedItemPanel;


	void Start(){
		selectedObject = null;
	}

	public void setSelectedItem(GameObject item)
	{
		if (selectedObject) {
			selectedObject.GetComponent<OutlineComponent> ().Disable ();
			selectedObject = null;
		}
		if (item) {
			item.GetComponent<OutlineComponent> ().Enable ();
			selectedObject = item;
		}
	}

	void Update() {
		/*if (Input.GetMouseButtonDown (0)) {
			Ray ray = gameCamera.GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if ( Physics.Raycast (ray,out hit,100.0f)){ 
				//suppose i have two objects here named obj1 and obj2.. how do i select obj1 to be transformed 
				GameObject hitObject = hit.collider.gameObject;
				if(hitObject != null && hitObject.GetComponent<OutlineComponent>() != null) { 
					if(selectedObject == hitObject)
					{
						setSelectedItem (null);
					} 
					else {
						setSelectedItem (hitObject);
					}
				} 
			}
		}*/
		if (selectedObject) {
			selectedItemPanel.SetActive (true);
			Upgradable upgradeComponent = selectedObject.GetComponent<Upgradable> ();
			Item itemComponent = selectedObject.GetComponent<Item> ();
			if (upgradeComponent) {
				if (upgradeComponent.isUpgradable ()) {
					upgradeCost.text = upgradeComponent.getUpgradeCost ().ToString ();
					upgradeButton.gameObject.SetActive (true);
				} else {
					upgradeCost.text = "N/A";
					upgradeButton.gameObject.SetActive (false);
				}
				sellAmount.text = upgradeComponent.getSellValue ().ToString ();
				if (itemComponent) {
					selectedItemText.text = itemComponent.itemName + " (Level " + upgradeComponent.level + ")";
					selectedItemImage.sprite = itemComponent.getImage ();
				}
			}

		} else {
			selectedItemPanel.SetActive (false);
		}

		moneyAmount.text = money.ToString ();
	}

	public bool purchase(Item purchaseItem)
	{
		if (money >= purchaseItem.GetPrice()) {
			money -= purchaseItem.GetPrice ();
			return true;
		}
		return false;
	}

	public void upgrade()
	{
		Upgradable upgrader = selectedObject.GetComponent<Upgradable>();
		if (upgrader.isUpgradable() && money >= upgrader.getUpgradeCost ()) {
			money -= upgrader.getUpgradeCost ();
			upgrader.Upgrade ();
		}
		
	}

	public void sell()
	{
		Upgradable upgrader = selectedObject.GetComponent<Upgradable>();
		if (upgrader) {
			money += upgrader.getSellValue ();
			Destroy (selectedObject);
			selectedObject = null;
		}

	}

	public void setItem(GameObject selectedButton)
	{
	}

}
