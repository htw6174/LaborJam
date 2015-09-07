using UnityEngine;
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

		if (thisItemsType == itemType.Add)
		{
			this.GetComponent<AudioSource>().Play();
			player.GetComponent<playerInventory>().inventory.Add(this);//new item(name, thisItemsType));
			this.GetComponent<BoxCollider>().enabled = false;
			this.GetComponent<MeshRenderer>().enabled = false;
			//Destroy(this.gameObject);
		}
		if (thisItemsType == itemType.Remove)
		{
			if (player.GetComponent<playerInventory>().inventory.Contains(RemoveMe))
			{
				player.GetComponent<playerInventory>().inventory.Remove(RemoveMe);

				if (name == "CktSlot")
				{
					player.GetComponent<gameWin>().swappedCktBoards = true;
				}

			}
			
		}
		if (thisItemsType == itemType.Interact)
		{
			this.GetComponent<AudioSource>().Play();
			if (name == "defaultItem")
			{
				Debug.Log("This is just a default item!!");
			}
			else if (name == "AuxPowerSwitch")
			{
				this.GetComponent<BoxCollider>().enabled = false;
				player.GetComponent<gameWin>().auxPowerActivated = true;
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
