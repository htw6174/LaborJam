using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countDown : MonoBehaviour {

	public float initialTime; // in seconds
	public bool timerOn = true; 
	//public float initialWait = 10.0f;//in seconds

	private float locTime; 
	private float locMinutes;
	private float locSeconds;
	//private string locMilli;

	private float SubtractingTime = 1;
	private bool rewindFlag = true;
	//private bool firstTime = true;

	// Use this for initialization
	void Start () 
	{
		locTime = initialTime;
		//StartCoroutine("initialDelay");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timerOn)
		{
			UpdateTime();
		}
	}


	void UpdateTime()
	{
		locTime -= Time.deltaTime * SubtractingTime;
		locMinutes = Mathf.Floor(locTime / 60);
		locSeconds = Mathf.Floor(locTime % 60);
		if (locSeconds == 60)
		{
			locSeconds = 0.0f;
		}
		//locMilli = Mathf.Floor((locTime*1000) % 1000).ToString("000");
		this.gameObject.GetComponent<Text>().text = locMinutes.ToString("00") + ":" +locSeconds.ToString("00"); //+ ":"+ locMilli;
		if (locTime <= 0)
		{
			locTime = 0;
		}

		if (locTime <= 0 && rewindFlag)
		{
			locTime = 0;
			SubtractingTime = -1 * GameObject.FindGameObjectWithTag("Player").GetComponent<rewind>().rewindFrameTime/GameObject.FindGameObjectWithTag("Player").GetComponent<rewind>().replayFrameTime;

			GameObject.FindGameObjectWithTag("Player").GetComponent<rewind>().rewindMe = true;
			rewindFlag = false;
		}
	}
/*
	IEnumerator initialDelay()
	{
		if (firstTime) 
		{
			firstTime = false;
			yield return new WaitForSeconds(initialWait);
		}
		else
		{
			timerOn = true;
		}

	}
*/
}
