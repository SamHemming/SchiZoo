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

	//------------------------------------------------------------------------

	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener(()=>InventoryToggle());
		inventoryPanel = GameObject.Find ("InventoryPanel");
		inventoryPanel.SetActive(false);
		inventoryList = GameObject.FindObjectOfType<GameController> ().player.inventory;
		itemSlotPrefab = (GameObject)Resources.Load("ItemSlot.prefab");
		itemPanel = GameObject.Find ("ItemPanel").GetComponent<Transform>();
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
		foreach (InteractableObject item in inventoryList) {
			GameObject itemSlot = Instantiate(itemSlotPrefab, itemPanel);

		}
	}

	//------------------------------------------------------------------------

	// Update is called once per frame
	void Update () {
		
	}
}
