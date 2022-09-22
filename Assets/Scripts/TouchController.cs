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
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero); // Raycast code taken from: https://forum.unity.com/threads/touch-detect-game-object.631951/
                    
                    if (hit.collider != null ) {
                        hit.collider.gameObject.transform.parent.GetComponent<Ball>().Hit();
                    }
                }
            }
        }
    }
}
