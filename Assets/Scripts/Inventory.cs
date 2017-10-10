using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	private Button inventoryButton;
	private GameObject inventoryPanel;
	private Transform itemPanel;
	private List<InteractableObject> inventoryList;
	private GameObject itemSlotPrefab;
	private List<GameObject> itemSlotList;
	private Button sortButton;
	private Text sortButtonText;
	private string sortType = "A-Z";

	//------------------------------------------------------------------------

	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener(()=>InventoryToggle());
		inventoryPanel = GameObject.Find ("InventoryPanel");
		itemPanel = GameObject.Find ("ItemPanel").GetComponent<Transform>();
		inventoryList = GameObject.FindObjectOfType<GameController> ().player.inventory;
		itemSlotPrefab = (GameObject)Resources.Load("ItemSlot");
		itemSlotList = new List<GameObject>();
		sortButton = GameObject.Find ("InventorySortButton").GetComponent<Button> ();
		sortButton.onClick.AddListener (() => SortInventory ());
		sortButtonText = sortButton.GetComponentInChildren<Text> ();

		inventoryPanel.SetActive(false);
	}

	//------------------------------------------------------------------------

	private void InventoryToggle() {
		//Debug.Log ("InventoryToggle Pressed");
		if (inventoryPanel.activeSelf) {
			inventoryPanel.SetActive (false);
		}
		else {
			inventoryPanel.SetActive (true);
			InventoryUpdate ();
		}
	}

	//------------------------------------------------------------------------

	private void InventoryUpdate() {
		foreach (GameObject item in itemSlotList) {	//remove the old itemSlot objects
			Destroy (item);
		}
		itemSlotList.Clear ();	//clear the list

		foreach (InteractableObject item in inventoryList) {	//make new itemSlot for every item in the inventory
			GameObject itemSlot = Instantiate(itemSlotPrefab, itemPanel);	//make new itemSlot from prefab
			itemSlotList.Add (itemSlot);	//add item to list
			itemSlot.GetComponent<ItemSlot>().Item = item;	//set itemSlot gameObjects property Item item from the inventory
		}
	}

	//------------------------------------------------------------------------

	private void SortInventory() {
		switch (sortType) {

		case "A-Z":
			//inventoryList.Sort ();
			sortType = "Z-A";
			break;

		case"Z-A":
			sortType = "type";
			break;

		case "type":
			sortType = "!type";
			break;

		case "!type":
			sortType = "A-Z";
			break;

		default:
			Debug.Log ("SortInventory default case.");
			break;
		}
		sortButtonText.text = sortType;	//Update sort buttons text
	}

	// Update is called once per frame
	void Update () {
		
	}
}
