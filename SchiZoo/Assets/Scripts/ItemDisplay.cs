using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

    public Text infoText;
    public Image sprite; 
    public delegate void ItemDisplayDelegate (InteractableObject item);
    public static event ItemDisplayDelegate onClick;
    public InteractableObject item;
	// Use this for initialization
	void Start () {
        if (item != null)
            Intialize(item);
	}
	// Update is called once per frame
	void Update () {
    }
    public void Intialize(InteractableObject item)
    {
        this.item = item;
        if (infoText != null)
        {
            infoText.text = item.itemInfo;
        }
        if (sprite != null)
        {
            sprite.sprite = item.itemSprite;
        }
    }
        public void Click()
    {   
        Debug.Log("Clikced");
        if (onClick != null)
        {
            onClick.Invoke(item);
        }
        else
        {
            Debug.Log("Nobody was listening");
        }
    }
}
