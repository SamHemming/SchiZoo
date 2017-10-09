using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    
    public List<InteractableObject> items= new List<InteractableObject>(); //list to use as inventory


    public Canvas canvasInventory;
    public Canvas canvasUI;
    private bool invOn;
    public Button buttonInventory;
    public Button closeInventoryButton;
    public InventoryDisplay inventoryDisplayPrefab;
    public Button itemSlot;
    private bool infoON;
    public Canvas infoText;
   
    public void InventoryActions (string action, InteractableObject item = null) {
        if (action == "Add") {
            items.Add(item);
        } else if (action == "Remove" && items.Contains (item)) {   //if item is in the list remove it
            items.Remove (item);
        } else if (action == "print") {
            string text = "";
            foreach (InteractableObject _item in items) {
                text += (_item.ToString() + ", ");
            }
            Debug.Log (text);
        }
    }
   	// Use this for initialization
    void Start () {
        InventoryDisplay inventory = (InventoryDisplay)Instantiate(inventoryDisplayPrefab);
        inventory.Intialize(items);

        canvasInventory = GameObject.Find("InventoryDisplay(Clone)").GetComponent<Canvas>();
        canvasUI = GameObject.Find("Canvas_UI").GetComponent<Canvas>();
        buttonInventory = GameObject.Find("InventoryButton").GetComponent<Button>();
        buttonInventory.onClick.AddListener(openInventory);    // run openInventory when pressed
        closeInventoryButton = GameObject.Find("CloseInventoryButton").GetComponent<Button>();
        closeInventoryButton.onClick.AddListener(closeInventory);     // run closeInventory when pressed
        infoText = GameObject.Find("infoCanvas").GetComponent<Canvas>();
        itemSlot = GameObject.Find("ItemSlot(clone)").GetComponent<Button>();
        itemSlot.onClick.AddListener(openInfo);
    }
    private void openInventory() 
    {
        if (invOn == false)  // if CanvasInventory is off
            canvasInventory.enabled = true;   // Sets CanvasInventory on
        invOn = true;
        canvasUI.enabled = false;   // Disables CanvasUI, hides InventoryButton
    }
    private void closeInventory()
    {
        if (invOn == true) // if inventory is off
            canvasInventory.enabled = false; //disables CanvasInventory
        invOn = false;
        canvasUI.enabled = true; // Enables CanvasUI, shows InventoryButton
    }
    private void openInfo()
    {
        if (infoON == false)
            infoText.enabled = true;
        infoON = true;
    }
	// Update is called once per frame
	void Update () {
		
	}
  
    }


