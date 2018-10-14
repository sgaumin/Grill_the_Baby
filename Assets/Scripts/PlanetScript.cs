using UnityEngine;

public class PlanetScript : MonoBehaviour {

    public float gravity = -10;

    private float radiusPlanet;

    public void Attract(Transform playerTransform)
    {
        Vector3 gravityUp = (playerTransform.position - transform.position).normalized;
        Vector3 localUp = playerTransform.up;

        float radiusPlanet = GetComponent<CircleCollider2D>().radius * transform.lossyScale.y;
        float radiusPlayer = playerTransform.GetComponent<CircleCollider2D>().radius;

        //float distance = Mathf.Abs((playerTransform.position - transform.position).magnitude - (radiusPlayer + radiusPlanet)*1.2f); 

        //playerTransform.GetComponent<Rigidbody2D>().AddForce(gravityUp * gravity * distance);

        if (!((playerTransform.position - transform.position).magnitude < (radiusPlayer + radiusPlanet) * 1.05))
        {
            playerTransform.GetComponent<Rigidbody2D>().AddForce(gravityUp * gravity);
            Debug.DrawLine(playerTransform.position, playerTransform.position + gravityUp * gravity);
        }

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * playerTransform.rotation;
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, 500f * Time.deltaTime);
    }
}
