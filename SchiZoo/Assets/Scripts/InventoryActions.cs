using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryActions : MonoBehaviour {
	// Use this for initialization
	void Start () {
        ItemDisplay.onClick += HandleonClick;
    }
    void Destroy() {
        Debug.Log("Not signed for click");
        ItemDisplay.onClick += HandleonClick;
    }
    void HandleonClick (InteractableObject item)
    {
        Debug.Log("Im heard "  +  item);
    }
	// Update is called once per frame
	void Update () {
		
	}
}

