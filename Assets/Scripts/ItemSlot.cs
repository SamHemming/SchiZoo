using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemSlot : MonoBehaviour {

	public InteractableObject Item { get; set;}	//item property of interactableItem type
	public static ItemSlot SelectedSlot { get; set; }

	public delegate void SlotChangeDelegate();	//make template for referensing methods
	public event SlotChangeDelegate SlotChangeEvent;	//when SelectedSlotChanged is called, all methods that fit into SlotChangeEvent are called

	private Button myButton;
	private Inventory invScript;
	private Text descriptionText;
	private Text headerText;

	//----------------------------------------------------------------------------------------

	void Start () {
		myButton = this.GetComponent<Button> ();
		myButton.onClick.AddListener (() => Select ());
		invScript = GameObject.FindObjectOfType<Inventory> ();
		SlotChangeEvent += new SlotChangeDelegate(SlotChangeHandler);
		descriptionText = GameObject.Find ("DescriptionText").GetComponent<Text> ();
		headerText = GameObject.Find ("DescriptionHeader").GetComponent<Text> ();
	}

	//----------------------------------------------------------------------------------------

	private void Select() {
		//Debug.Log ("Select fired from: " + this.GetInstanceID());
		SelectedSlot = this;
		SlotChangeEvent ();
	}

	//----------------------------------------------------------------------------------------

	void SlotChangeHandler() {
		if (SelectedSlot == this) {
			myButton.GetComponent<Image> ().color = Color.red;
			Debug.Log ("SlotChangeHandler fired in if: " + this.GetInstanceID());
			descriptionText.text = Item.description;
			headerText.text = Item.name;
		}
		else {
			myButton.GetComponent<Image> ().color = Color.white;
			Debug.Log ("SlotChangeHandler fired in else: " + this.GetInstanceID());
		}
	}
}