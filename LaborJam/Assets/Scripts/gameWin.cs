using UnityEngine;
using System.Collections;

public class gameWin : MonoBehaviour {

	public bool auxPowerActivated, swappedCktBoards = false;

	// Update is called once per frame
	void Update () 
	{
		if (auxPowerActivated && swappedCktBoards)
		{
			triggerEnding();
		}
	}

	void triggerEnding()
	{
		Application.LoadLevel(Application.loadedLevel+1);
	}

}
