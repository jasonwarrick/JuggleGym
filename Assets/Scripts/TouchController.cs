using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    void Update(){
        GetInput();
    }

    private void GetInput() {
        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; i++) { // Debouncing code taken from https://forum.unity.com/threads/how-to-let-my-counter-only-detect-a-single-touch-input.562381/
                if (Input.GetTouch(i).phase == TouchPhase.Began) { 
                    Vector3 convertedPoint = Camera.main.ScreenToWorldPoint((Input.GetTouch(i).position)); // Convert the pixel coordinate of the hit to the world coordinate
                    RaycastHit2D hit = Physics2D.Raycast(convertedPoint, Vector2.zero); // Raycast code taken from: https://forum.unity.com/threads/touch-detect-game-object.631951/

                    if (hit.collider != null ) {
                        if (hit.collider.gameObject.CompareTag("Borders")) { // Ignore the hit if it is colliding with the borders of the level
                            continue;
                        }

                        Transform parentTransform = hit.collider.gameObject.transform.parent;

                        parentTransform.GetComponent<Ball>().Hit(convertedPoint);
                    }
                }
            }
        }
    }
}
