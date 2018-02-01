using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour {

	public float wait;

	// Use this for initialization
	void Start () {
		StartCoroutine (Destroy (wait));
	}
	
	IEnumerator Destroy(float wait){
		yield return new WaitForSeconds (wait);
		Destroy (gameObject);
	}
}
