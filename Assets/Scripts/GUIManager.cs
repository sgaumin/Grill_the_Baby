using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	public static GUIManager instance = null;

	public GameObject[] heartTab;
	public Text phaseText;
	public Text scoreText;
	public Image winImage;
	public Image loseImage;
	[HideInInspector]
	public int scoreValue = 0;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	void Start(){

		if (winImage != null) {
			winImage.gameObject.SetActive (false);	
		}

		if (loseImage != null) {
			loseImage.gameObject.SetActive (false);	
		}
			
		if (true) {
			scoreText.text = "" + scoreValue;	
		}
	}

	public void ChangeScore(int value){
		scoreValue += value;
		scoreText.text = "" + scoreValue;
	}

	public void ShowPhase(int phaseNumber){
		phaseText.text = "PHASE " + phaseNumber; 
		phaseText.gameObject.SetActive (true);
		AudioManager.instance.PlayAlarm ();
	}

	public void ShowWinGame(){
		winImage.gameObject.SetActive (true);
	}

	public void ShowLoseGame(){
		loseImage.gameObject.SetActive (true);
	}

	public void HidePhase(){
		phaseText.gameObject.SetActive (false);
		AudioManager.instance.StopAlarm ();
	}

	public void ChangeLife(int value){

		for (int i = 0; i < heartTab.Length; i++) {
			heartTab [i].gameObject.SetActive (false);
		}

		for (int i = 0; i < value; i++) {
			heartTab [i].gameObject.SetActive (true);
		}
	}
}
