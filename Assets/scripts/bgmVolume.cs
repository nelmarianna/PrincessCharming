﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgmVolume : MonoBehaviour {

	AudioSource audio;
	GameObject levelSelMusic;
	musicSettings musicSett;
	private static bgmVolume instance = null;

	public static bgmVolume Instance(){
		return instance;
	}

	void Start(){
		audio = GetComponent<AudioSource> ();

		GameObject settings = GameObject.FindGameObjectWithTag("musicVol"); 
		musicSett = (musicSettings)settings.GetComponent (typeof(musicSettings));
	}
	void Awake(){
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
			DontDestroyOnLoad (this.gameObject);
	}

	void Update(){
		if (SceneManager.GetActiveScene ().buildIndex == 0 || SceneManager.GetActiveScene ().buildIndex == 1) {
			DontDestroyOnLoad (this.gameObject);

			levelSelMusic = GameObject.FindGameObjectWithTag ("selectMusic");
			if (levelSelMusic != null) {
				levelSelMusic.SetActive (false);

			}
		}
		else
			Destroy (this.gameObject);
	}

	
	public void SetVolume(float value){
		audio.volume = value;
		musicSett.SetMusicVolume(value);
	}
		
}
