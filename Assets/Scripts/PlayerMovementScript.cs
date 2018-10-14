using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public float inputSmoothTime = 1f;

    private Vector3 moveDirection;
    private float currentInput = 0;
    private float currentInputSpeed = 0;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        currentInput = Mathf.SmoothDamp(currentInput, Input.GetAxisRaw("Horizontal"), ref currentInputSpeed, inputSmoothTime);
    }

    void FixedUpdate()
    {
        Vector3 velocity = (Vector3) rb.velocity;
        Vector3 localVelocity = transform.InverseTransformVector(velocity);
        localVelocity.x = currentInput * moveSpeed;
        Vector3 newVelocity = transform.TransformVector(localVelocity);
        
        rb.AddForce(newVelocity - velocity, ForceMode2D.Impulse);

        //Vector2 _pos = new Vector2(transform.TransformDirection(moveDirection).x, transform.TransformDirection(moveDirection).y).normalized;
        //GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + _pos * moveSpeed * Time.fixedDeltaTime);
        //GetComponent<Rigidbody2D>().AddForce(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
