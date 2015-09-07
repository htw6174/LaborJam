using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerInventory : MonoBehaviour {

	public List<item> inventory = new List<item>();


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach (item i in inventory)
		{
			Debug.Log(i.name);
		}

	}
}
