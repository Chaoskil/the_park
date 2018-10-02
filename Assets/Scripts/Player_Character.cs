using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character : MonoBehaviour {

    [SerializeField]
    private float accelearationForce = 5;

    [SerializeField]
    private float maxSpeed = 10;

    [SerializeField]
    private Rigidbody2D rb2d;

    private float horizontalInput;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * horizontalInput * accelearationForce);
        Vector2 clampedVelocity = rb2d.velocity;
        clampedVelocity.x = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = clampedVelocity;
    }
}
