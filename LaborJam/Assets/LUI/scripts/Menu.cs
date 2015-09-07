using UnityEngine;
using System.Collections;

/// <summary>
/// Classs Menu
/// 
/// 
/// each Menu instance must have a name assigned in the editor
/// each Menu instance will assume and use the Camera.main to render its camera.screenspace camera unless the useMainCamera bool is set false
/// 
/// </summary>

public class Menu : MonoBehaviour {

	public string name;
	public bool useMainCamera = true;
	public float planeDistance = 15;

	// Use this for initialization
	void Start () 
	{
		gameObject.GetComponent<Canvas>().planeDistance = planeDistance;
		if (useMainCamera)
			gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
	}

	void OnLevelWasLoaded()
	{
		gameObject.GetComponent<Canvas>().planeDistance = planeDistance;
		if (useMainCamera)
			gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
	}
	
	// Update is called once per frame
}
