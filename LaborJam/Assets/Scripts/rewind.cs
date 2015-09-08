using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Audio;

public class rewind : MonoBehaviour {

	public bool rewindMe = false;
	public float rewindFrameTime = 1.0f;
	public float replayFrameTime = 0.3f;
	public AudioMixer myAudioMixer;
	public AudioMixerSnapshot RewindSnap;
	public AudioMixerSnapshot NormalSnap;

	private List<Vector3> positions = new List<Vector3>();
	private List<Quaternion> rotations = new List<Quaternion>();
	private Camera mainCam;
	private int i = 0;
	private AudioSource myRewindSound;

	// Use this for initialization
	void Start () 
	{
		myAudioMixer.SetFloat("sfxVol",0.75f);
		myAudioMixer.SetFloat("musicVol",0.75f);

		mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		myRewindSound = this.gameObject.GetComponent<AudioSource>();
		RewindSnap = myAudioMixer.FindSnapshot("Rewind");
		NormalSnap = myAudioMixer.FindSnapshot("Normal");
		NormalSnap.TransitionTo(.5f);
		StartCoroutine("record");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (rewindMe)
		{
			gameObject.GetComponent<RigidbodyFirstPersonController>().enabled = false;
			gameObject.GetComponent<Rigidbody>().useGravity = false;
			gameObject.GetComponent<Rigidbody>().isKinematic = true;
			RewindSnap.TransitionTo(0.3f);
			myAudioMixer.SetFloat("sfxVol",-79.0f);
			myAudioMixer.SetFloat("musicVol",-79.0f);
			myRewindSound.Play();

			i = positions.Count-1;
			StartCoroutine("replay");
			rewindMe = false;
		}
	}

	IEnumerator record()
	{
		for (;;) //always
		{
			rotations.Add(mainCam.transform.rotation);
			positions.Add(this.gameObject.transform.position);
			yield return new WaitForSeconds(rewindFrameTime);
		}
	}

	IEnumerator replay()
	{
		for (;i>=0;i--) 
		{
			mainCam.transform.rotation = rotations[i];
			this.gameObject.transform.position = positions[i];
			yield return new WaitForSeconds(replayFrameTime);
		}
		Application.LoadLevel(Application.loadedLevel);
	}
}
