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

	public delegate void SlotChangeDelegate();	//delegate for the event
	public event SlotChangeDelegate SlotChangeEvent;	//event that is called when ItemSlot is selected

	//------------------------------------------------------------------------

	public void RiseSlotChangeEvent() {	//called by ItemSlot when it is selected/clicked
		SlotChangeEvent ();	//call all event subs
	}

	//------------------------------------------------------------------------

	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener(()=>InventoryToggle());	//onClick run InventoryToggle
		inventoryPanel = GameObject.Find ("InventoryPanel");	
		itemPanel = GameObject.Find ("ItemPanel").GetComponent<Transform>();	//get reference to itemPanel for parenting ItemSlots
		inventoryList = GameObject.FindObjectOfType<GameController> ().player.inventory;	//get ref to players inv
		itemSlotPrefab = (GameObject)Resources.Load("ItemSlot");	//get ref to ItemSlots prefab
		itemSlotList = new List<GameObject>();	//make new list to store itemSlot buttons
		sortButton = GameObject.Find ("InventorySortButton").GetComponent<Button> ();	//get ref to invSort button
		sortButton.onClick.AddListener (() => SortInventory ());	//when invSort button is clicked run SortInventory method
		sortButtonText = sortButton.GetComponentInChildren<Text> ();	//ref to sort buttons text

		inventoryPanel.SetActive(false);	//toggle inventoryPanel off so that it is hidden
	}

	//------------------------------------------------------------------------

	private void InventoryToggle() {	//toggle inventory on/off
	//	Debug.Log ("InventoryToggle Pressed");
		if (inventoryPanel.activeSelf) {
			inventoryPanel.SetActive (false);	//set inv off so it gets hidden
		}
		else {
			inventoryPanel.SetActive (true);
			InventoryUpdate ();	//update inventory
		}
	}

	//------------------------------------------------------------------------

	private void InventoryUpdate() {	//delete old buttons and make new once from the inventory
		foreach (GameObject item in itemSlotList) {	//remove the old itemSlot objects
			Destroy (item);	//destroy item object
		}
		itemSlotList.Clear ();	//clear the list

		foreach (InteractableObject item in inventoryList) {	//make new itemSlot for every item in the inventory
			GameObject itemSlot = Instantiate(itemSlotPrefab, itemPanel);	//make new itemSlot from prefab
			itemSlotList.Add (itemSlot);	//add item to list
			itemSlot.GetComponent<ItemSlot>().Item = item;	//set itemSlot gameObjects property Item item from the inventory
		}
	}

	//------------------------------------------------------------------------

	private void SortInventory() {	//sort inventory by given type
	
		sortButtonText.text = sortType;	//Update sort buttons text

		switch (sortType) {

		case "Z-A":
			inventoryList.Sort (((x, y) => x.name.CompareTo (y.name)));	//sort inventory list by compareing X and Y, where x is first items name and y is next items name
			sortType = "A-Z";	//set sort type for next run
			break;

		case"A-Z":
			inventoryList.Sort (((x, y) => y.name.CompareTo (x.name)));
			sortType = "type";
			break;

		case "type":
			inventoryList.Sort (((x, y) => x.type.CompareTo (y.type)));
			sortType = "!type";
			break;

		case "!type":
			inventoryList.Sort (((x, y) => y.type.CompareTo (x.type)));
			sortType = "Z-A";
			break;

		default:
			Debug.Log ("SortInventory default case.");
			break;
		}
	//	GameObject.FindObjectOfType<GameController> ().player.Inventory ("Print");
		InventoryUpdate ();	//update inv to give buttons new positions
	}
}
