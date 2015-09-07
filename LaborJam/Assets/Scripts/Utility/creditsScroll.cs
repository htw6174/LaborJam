using UnityEngine;
using System.Collections;

public class creditsScroll : MonoBehaviour {

	public float initialDelay = 5.0f;
	public float speed = .5f;

	private bool startMoving = false;	
	private bool firstPlay = true;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine("delayStart");
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (startMoving)
		{
			this.gameObject.transform.Translate(0.0f,speed,0.0f);
		}
		
	}
	
	IEnumerator delayStart()
	{
		for (;;) //always
		{
			if (firstPlay)
			{
				firstPlay = false;
				yield return new WaitForSeconds(initialDelay);
			}
			else
			{
				//				Debug.Log("initial delay was passed and sound is playing regularly");
				startMoving = true;
				yield return new WaitForSeconds(0.0f);
			}
		}
	}
	
	
}
