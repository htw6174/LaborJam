using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class sliderToMixerLevel : MonoBehaviour {

	public string property;
	public AudioMixer masterMixer;

	private float VolumeSliderGet;
	private float setValue;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		VolumeSliderGet = this.gameObject.GetComponent<Slider>().value;
		setValue = (VolumeSliderGet-1)*80;
		masterMixer.SetFloat(property, setValue );
	}
}
