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

    public void Hit(Vector2 touchPos) {
        transform.parent.gameObject.GetComponent<Spawner>().Hit();
        
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset the y-velocity that way each bounce is consistent

        Vector2 posXY = new Vector2(rb.transform.position.x, rb.transform.position.y);
        Vector2 newDirection = (posXY - touchPos).normalized; // Get the direction between where the ball was hit and where it is

        newDirection = new Vector2(newDirection.x, Mathf.Abs(newDirection.y)); // Make sure the y-direction is always positive so the player can't hit a ball down

        rb.AddForce(((newDirection + Vector2.up) / 2) * bounceForce); // Average newDirection with up so the ball gets launched more upwards
    }
}
