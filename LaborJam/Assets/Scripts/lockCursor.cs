using UnityEngine;
using System.Collections;

public class lockCursor : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			Cursor.visible = !Cursor.visible;
		    Cursor.lockState= CursorLockMode.None;
		}
	}
}
