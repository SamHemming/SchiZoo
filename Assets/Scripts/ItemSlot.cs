using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemSlot : MonoBehaviour {

	public InteractableObject Item { get; set;}	//item property of interactableItem type
	public static ItemSlot SelectedSlot { get; set; }	//static property for all item slots

	private Button myButton;
	private Inventory invScript;
	private Text descriptionText;
	private Text headerText;
	private Image myImage;

	//----------------------------------------------------------------------------------------

	void Start () {
		myButton = this.GetComponent<Button> ();	//get ref to own button component
		myButton.onClick.AddListener (() => Select ());	//when this button is pressed run select method
		myImage = myButton.GetComponent<Image>();	//get ref to image component
		invScript = GameObject.Find ("InventoryButton").GetComponent<Inventory> ();	//get ref to main inv script
		invScript.SlotChangeEvent += this.SlotChangeHandler;	//sub for the event
		descriptionText = GameObject.Find ("DescriptionText").GetComponent<Text> ();	//get ref to descText
		headerText = GameObject.Find ("DescriptionHeader").GetComponent<Text> ();
		this.GetComponentInChildren<Text> ().text = this.Item.name;	//set button text to be the name of buttons item
	}

	//----------------------------------------------------------------------------------------

	void OnDestroy () {	//when this is destroyed
		invScript.SlotChangeEvent -= this.SlotChangeHandler;	//un-sub from the event	to prevent this from being called after its destruction(to prevent nullrefexeption)
	}

	//----------------------------------------------------------------------------------------

	private void Select() {	//when button is pressd
	//	Debug.Log ("Select fired from: " + this.GetInstanceID());
		SelectedSlot = this;	//set the static selected to be this
		invScript.RiseSlotChangeEvent ();	//rise event call so that everyone knows that the property was updated
	}

	//----------------------------------------------------------------------------------------

	void SlotChangeHandler() {	//when SelectedSlot is updated
		if (SelectedSlot == this) {	//if this was selected
			myImage.color = Color.red;	//set color red for highlight
		//	Debug.Log ("SlotChangeHandler fired in if: " + this.GetInstanceID());
			descriptionText.text = Item.description;	//update desc box
			headerText.text = Item.name;	//update desc header
		}
		else {
			myImage.color = Color.white;	//set color white to de-highlight
		//	Debug.Log ("SlotChangeHandler fired in else: " + this.GetInstanceID());
		}
	}
}