using UnityEngine;
using System.Collections;

public class resetLevel : MonoBehaviour {

	public bool gameOver = false;
	

	// Update is called once per frame
	void Update () 
	{
		if (gameOver)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
