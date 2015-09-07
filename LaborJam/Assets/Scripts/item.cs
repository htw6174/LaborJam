﻿using UnityEngine;
using System.Collections;

public class item : MonoBehaviour {




	public string name = "defaultItem";
	public itemType thisItemsType;

	public item RemoveMe;


	private GameObject player; 

	item(string Name, itemType ThisItemsType)
	{
		name = Name;
		thisItemsType = ThisItemsType;
	}

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void interact()
	{
		Debug.Log("interact was called");
		if (thisItemsType == itemType.Add)
		{
			player.GetComponent<playerInventory>().inventory.Add(new item(name, thisItemsType));
			Destroy(this.gameObject);
		}
		if (thisItemsType == itemType.Remove)
		{
			player.GetComponent<playerInventory>().inventory.Remove(RemoveMe);
		}
		if (thisItemsType == itemType.Interact)
		{
			if (name == "defaultItem")
			{
				Debug.Log("This is just a default item!!");
			}
		}

	}
}
public enum itemType
{
	Add, 
	Remove,
	Interact
}
