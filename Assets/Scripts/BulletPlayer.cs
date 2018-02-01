using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D _RB;

	// Use this for initialization
	void Start () {
		_RB = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		_RB.velocity = gameObject.transform.up * moveSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
