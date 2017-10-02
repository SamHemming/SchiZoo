using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogController : MonoBehaviour {

	private List<string> sentences;	//list of strings called sentences
	private Text header;	//header of dialogbox
	private Text dialogText;	//text of dialogbox
	private Animator animator;	//animation of dialogbox
	private Dialog dialog;	//dialog object
	private int sentenceCounter;
	private Button button1;
	private Button button2;
	private Button button3;
	private string[,] commandArray;


	// Use this for initialization
	void Start () {
		sentences = new List<string>();	//initiated sentences
		sentenceCounter=0;
		header = GameObject.Find ("DialogHeader").GetComponent<Text> ();
		dialogText = GameObject.Find ("DialogText").GetComponent<Text> ();
		animator = GameObject.Find ("DialogueBox").GetComponent<Animator> ();
		button1 = GameObject.Find ("Button_Option1").GetComponent<Button> ();
		button1.onClick.AddListener (()=>DialogButton("Option1"));
		button2 = GameObject.Find ("Button_Option2").GetComponent<Button> ();
		button2.onClick.AddListener (()=>DialogButton("Option2"));
		button3 = GameObject.Find ("Button_Option3").GetComponent<Button> ();
		button3.onClick.AddListener (()=>DialogButton("Option3"));
	}	//made button_option1 run displaynextsentence method

	private void DialogButton(string option) {
		switch (option) {
		case "Option1":
			if (dialog.commands != null) {
				
			}
			break;
		case "Option2":
			break;
		case "Option3":
			break;
		default:
			Debug.Log ("DialogButton Default case.");
			break;
		}
	}

	public void StartDialog(Dialog dialogTemp) {	//start dialog of argument dialog
		//Debug.Log ("Dialog started with " + dialog.name);
		dialog = dialogTemp;
		commandArray = InterpretCommands (dialog.commands);
		animator.SetBool("IsOpen", true);	//run dialog opening animation
		header.text = dialog.header;	//set the dialogheader
		sentences.Clear ();	//clear queue
		sentences= dialog.sentences;


		DisplayNextSentence ();


	}

	private string[,] InterpretCommands(string[] commands) {
		string[,] slicedCommands = new string[commands.Length,4];
		string temp="";
		int row=0;
		foreach (string command in commands) {
			int column=0;
			foreach(char letter in command.ToCharArray()){
				if(letter.Equals(';')){
					slicedCommands[row,column]=temp;
					column++;
					temp="";
				}else {
					temp+=letter;
				}
			}
			row++;
		}
		return slicedCommands;
	}

	public void DisplayNextSentence() {
		if (sentenceCounter == sentences.Count) {	//if no sentence in queue
			EndDialog ();
		} else {
			string sentence = sentences[sentenceCounter];	//take first sentence and remove it from the queue
			StopAllCoroutines();	//stop previous coroutine
			StartCoroutine(TypeSentence(sentence));	//start coroutine that types the dialog
			//dialog.text = sentence;
			//Debug.Log (sentence);
			UpdateButtons ();
			sentenceCounter++;

		}
	}


	IEnumerator TypeSentence (string sentence) {	//add one letter to the dialog every frame
		dialogText.text = "";	//clear the dialog text
		foreach (char letter in sentence.ToCharArray()) {	//for each letter in sentence
			dialogText.text += letter;	//add the letter to dialog
			yield return null;	//mandatory yield
		}
	}

	private void EndDialog() {
		animator.SetBool ("IsOpen", false);	//run dialog closing animation
		Debug.Log ("End of dialog");
	}

	public void UpdateButtons(){
		//Debug.Log ("meneeeeeköööö");
		for(int row=0; row<commandArray.GetLength(0); row++){
			//Debug.Log ("For loop alkaa"+sentenceCounter.ToString());
			if (commandArray [row, 0].Equals (sentenceCounter.ToString ())) {
				//Debug.Log ("ulompi if alkaa");
				if (commandArray [row, 1].Equals ("1")) {
					button1.GetComponentInChildren<Text> ().text = commandArray [row, 2];
					//Debug.Log ("nappi 1");
				} else if (commandArray [row, 1].Equals ("2")) {
					button2.GetComponentInChildren<Text> ().text = commandArray [row, 2];			
					//Debug.Log ("nappi 2");
				} else if (commandArray [row, 1].Equals ("3")) {
					button3.GetComponentInChildren<Text> ().text = commandArray [row, 2];
					//Debug.Log ("nappi 3");
				} else {
					Debug.Log ("Something gone wrong!");
				}
			} else {
				Debug.Log ("Problems");
			}

		}
	}
}
