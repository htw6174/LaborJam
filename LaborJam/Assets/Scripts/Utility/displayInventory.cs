using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayInventory : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.GetComponent<Text>().text = "Inventory : \n";
		if (player.GetComponent<playerInventory>().inventory.Count > 0)
		{
			foreach (item i in player.GetComponent<playerInventory>().inventory)
			{
				this.gameObject.GetComponent<Text>().text += "\n" + i.name; 
			}
		}
	}
}
