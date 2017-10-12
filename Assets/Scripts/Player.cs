using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {
	
	private string myname;
	private Canvas location;	//var for location
	public List<InteractableObject> inventory = new List<InteractableObject>();	//list to use as inventory
	private double clothes;

	//--------------------------------------------------------------------------------------------

	public void SetLocation (Canvas loc) {
		if (location != null) { //if location is set
			location.enabled = false; //set location off
		}
		this.location = loc;	//set new location
		location.enabled = true;	//set new location on
	}

	//----------------------------------------------------------------------------------------------

	public void Inventory (string action, InteractableObject item = null) {
		if (action == "Add") {
			inventory.Add (item);	//add item to inventory list
		}
		else if (action == "Remove" && inventory.Contains (item)) {	//if item is in the list remove it
			inventory.Remove (item);
		}
		else if (action == "Print") {	//print inventory for debug
			string text = "";
			foreach (InteractableObject itemOfInventory in inventory) {
				text += (itemOfInventory.type + ": " + itemOfInventory.name + ", ");
			}
			Debug.Log (text);
		}
	}

	//-------------------------------------------------------------------------------------------

	public bool InventoryContain (string objective) {	//check if there is item with given sideobjective in inventory and return bool acordingly
		foreach (InteractableObject item in inventory) {	//for each object in inventory
			if (item.sideObjective.Equals (objective)) {	//check if the sidebjective equals objective
				return true;	//if so return true
			}
		}
		return false;	//if non of the items return true, return false
	}

	//--------------------------------------------------------------------------------------------

	public void DressUp(string name){	//add clothes score based on what item was picked
		if (this.clothes >= 1) {	//when the score is 1 or more
			Debug.Log ("You are fully dressed");	//player is fully dressed
		} else if (name.Equals ("Socks")) {	//socks
			this.clothes += 0.25;	//give 0.25 points
		} else if (name.Equals ("T-Shirt")) {
			this.clothes += 0.25;
		} else if (name.Equals ("Jeans")) {
			this.clothes += 0.25;
		} else if (name.Equals ("Hoodie")) {
			this.clothes += 0.25;
		} else {
			Debug.Log ("Clothing not found");
		}
		Debug.Log (this.clothes);
	}

	//-----------------------------------------------------------------------------------------

	public Player (string name) {
		this.myname = name;
		this.clothes = 0;
	}
}

