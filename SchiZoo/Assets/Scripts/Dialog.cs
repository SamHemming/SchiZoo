using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]	//for unity editor
public class Dialog : MonoBehaviour {

	public string header;

	[TextArea(3, 10)]	//for unity editor
	public List <string> sentences;	//array of strings for dialog

	[TextArea(3, 10)]	//for unity editor
	public string [] commands;	//array of strings for dialog buttons

	void Start(){
		this.GetComponent<Button> ().onClick.AddListener (TriggerDialog);	//run triggerDialog when this button is pressed
	}

	private void TriggerDialog() {
		FindObjectOfType<DialogController> ().StartDialog (this);	//call dialogController to run this dialog
	}
}
