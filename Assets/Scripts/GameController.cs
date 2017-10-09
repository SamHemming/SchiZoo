using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	private List<Canvas> canvaslist = new List<Canvas> (); //make list of canvases
	public Player player = new Player ("Kake");	//make new player with name "Kake"
    public Inventory items;
	// Use this for initialization
	void Start () {

		//add all canvases to the canvaslist
		canvaslist.Add (GameObject.Find ("Canvas_LobbyLeft").GetComponent<Canvas> ());
		canvaslist.Add (GameObject.Find ("Canvas_Toilet").GetComponent<Canvas> ());
		canvaslist.Add (GameObject.Find ("Canvas_Bedroom").GetComponent<Canvas> ());
		canvaslist.Add (GameObject.Find ("Canvas_Livingroom").GetComponent<Canvas> ());
		canvaslist.Add (GameObject.Find ("Canvas_Kitchen").GetComponent<Canvas> ());
		canvaslist.Add (GameObject.Find ("Canvas_Closet").GetComponent<Canvas> ());
		canvaslist.Add (GameObject.Find ("Canvas_LobbyRight").GetComponent<Canvas> ());

		//make all canvases hidden and set rendermode right
		foreach (Canvas canvas in canvaslist) {
			canvas.enabled = false;
			canvas.renderMode = RenderMode.ScreenSpaceCamera;
		}

		//set playerlocation
		player.SetLocation (canvaslist [2]);
       
	}
}
