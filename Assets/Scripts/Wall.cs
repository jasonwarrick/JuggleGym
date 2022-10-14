using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    
    [SerializeField] float timeFactor;
    float newA = 0f;

    void OnCollisionEnter2D(Collision2D other) {
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    void FixedUpdate() {
        if (spriteRenderer.color.a > 0) {
            newA  = spriteRenderer.color.a - timeFactor;

            spriteRenderer.color = new Color(1f, 1f, 1f, newA);
        }
    }
}
