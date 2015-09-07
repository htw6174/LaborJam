using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	
	public float doorHeight = 2.0f; //How far the door will move
	public float doorSpeed = .1f;
	public float doorCloseRange = 5.0f;
	
	
	private Transform player;
	private Vector3 originalPosition;
	private bool openMe;
	private bool closeMe;

	private bool playOnce = true;
	
	void Start()
	{
		originalPosition = GetComponentInParent<Transform>().position;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		StartCoroutine("closeDetect");
		
	}
	
	void Update()
	{
		if (openMe && transform.position.y - originalPosition.y < doorHeight) 
		{
			if (playOnce && !this.gameObject.GetComponent<AudioSource>().isPlaying)
				this.gameObject.GetComponent<AudioSource>().Play();
			playOnce = false;
			transform.position += new Vector3 (0, doorSpeed, 0);
		} 
		else 
		{
			openMe = false;
		}
		if (!openMe && closeMe && transform.position.y - originalPosition.y > 0) 
		{
			if (playOnce && !this.gameObject.GetComponent<AudioSource>().isPlaying)
				this.gameObject.GetComponent<AudioSource>().Play();
			playOnce = false;
			transform.position -= new Vector3 (0, doorSpeed, 0);
		} 
		else 
		{
			closeMe = false;
		}
		//transform.position = new Vector3 (Mathf.PingPong (Time.time, doorWidth), transform.position.y, transform.position.z);
	}
	
	
	
	void interact()
	{
		playOnce = true;
		openMe = true;
	}
	
	IEnumerator closeDetect()
	{
		for (;;) //always
		{ 
			if (Vector3.Distance(transform.position,player.position)> doorCloseRange)
			{	
				playOnce = true;
				closeMe = true;
			}
			//Debug.Log(closeMe);
			yield return new WaitForSeconds(.2f);
		}
	}
	
}
