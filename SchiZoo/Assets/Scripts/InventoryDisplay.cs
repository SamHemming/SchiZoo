using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay: MonoBehaviour {
   
    public Transform targetTransform;
    public ItemDisplay itemSlotPrefab;

	// Use this for initialization
    void Start () {
    }
	// Update is called once per frame
    void Update () {
        
    }
    public void Intialize(List<InteractableObject> items)
    {
        foreach (InteractableObject item_1 in items)
        { 
            ItemDisplay display = (ItemDisplay)Instantiate(itemSlotPrefab);
            display.transform.SetParent(targetTransform, false);
            display.Intialize(item_1);
        }
        }
}
           
