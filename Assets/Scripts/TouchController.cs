using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    [SerializeField] AudioSource tapNoise;

    [SerializeField] float radius;

    void Update(){
        GetInput();
    }

    void GetInput() {
        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; i++) {
                TapBall(i);
            }
        }
    }

    void TapBall(int index) {
        if (Input.GetTouch(index).phase == TouchPhase.Began) { 
            Vector3 convertedPoint = Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)); // Convert the pixel coordinate of the hit to the world coordinate
            RaycastHit2D hit = Physics2D.CircleCast(convertedPoint, radius,  Vector2.zero); // Raycast code taken from: https://forum.unity.com/threads/touch-detect-game-object.631951/

            if (hit.collider != null ) {
                if (hit.collider.gameObject.CompareTag("Borders")) { // Ignore the hit if it is colliding with the borders of the level
                    return;
                }

                Transform parentTransform = hit.collider.gameObject.transform.parent;

                parentTransform.GetComponent<Ball>().Hit(convertedPoint);
                tapNoise.Play();
            }
        }
    }
}
