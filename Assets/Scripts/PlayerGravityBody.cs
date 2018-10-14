using UnityEngine;

public class PlayerGravityBody : MonoBehaviour {

    public PlanetScript attractorPlanet;
    private Transform playerTransform;

    void Start()
    {
        //GetComponent<Rigidbody2D>().useGravity = false;
        //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        playerTransform = transform;
    }

    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(playerTransform);
        }
    }
}
