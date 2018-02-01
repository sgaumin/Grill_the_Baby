using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;

    private Vector3 moveDirection;

    void Update()
    {
		#if UNITY_EDITOR
		moveDirection = new Vector3 (Input.acceleration.x, 0, 0).normalized;
		#endif

		#if UNITY_IOS
		moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0,0).normalized;
		#endif
    }

    void FixedUpdate()
    {	
		Vector2 _pos = new Vector2 (transform.TransformDirection (moveDirection).x, transform.TransformDirection (moveDirection).y);
		GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + _pos * moveSpeed * Time.deltaTime);
	}
}
