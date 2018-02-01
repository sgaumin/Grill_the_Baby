using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance = null;

	public AudioClip[] backgroundMusics;

	private AudioSource[] _AS;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (this);
		}
	}

	// Use this for initialization
	void Start () {
		_AS = GetComponents<AudioSource> ();
	}
	
	public void PlayWinSound(){
		_AS [0].Play ();
	}

	public void PlayLoseSound(){
		_AS [1].Play ();
	}

	public void PlayClickSound(){
		_AS [2].Play ();
	}

	public void PlayMenuMusic(){
		_AS [3].clip = backgroundMusics [0];
		_AS [3].Play ();
	}

	public void PlayGameMusic(){
		_AS [3].clip = backgroundMusics [1];
		_AS [3].Play ();
	}

	public void PlayAlarm(){
		_AS [4].Play ();
	}

	public void StopAlarm(){
		_AS[4].Stop();
	}

}
