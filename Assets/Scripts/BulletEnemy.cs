using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D _RB;
	private PlayerManager _PM;
	private Vector2 _pos;

	// Use this for initialization
	void Start () {
		_RB = GetComponent<Rigidbody2D> ();
		_PM = FindObjectOfType<PlayerManager> ();

		_pos = _PM.gameObject.transform.position - transform.position;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerManager> ().AddDamage (1);
			Destroy (gameObject);
		} else if (other.gameObject.tag == "Planet") {
			Destroy (gameObject);
		}
	}

	void FixedUpdate () {
		_RB.velocity = _pos * moveSpeed;
	}
}
