using System.Collections;
using System.Collections.Generic;

public class Room {
	
	private string name;
	private string image;

	public Room (string name, string img) {
		this.name = name;
		this.image = img;
	}

	public string GetName () {
		return this.name;
	}

	// Use this for initialization
	void Start () {
		
	}
}
