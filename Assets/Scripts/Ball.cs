using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float bounceForce;
    CircleCollider2D ballCollider;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        ballCollider = GetComponentInChildren<CircleCollider2D>();
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    public void Hit() {
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the y-velocity that way each bounce is consistent
        rb.AddForce(Vector2.up * bounceForce);
    }
}
