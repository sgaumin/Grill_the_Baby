using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_backup : MonoBehaviour {

	public static GameManager_backup Instance = null;

	void Awake(){
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (this);
		} else {
			Destroy (this);
		}
	}
		
}
