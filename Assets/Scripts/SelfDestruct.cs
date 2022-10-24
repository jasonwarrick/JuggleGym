using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    float timer = 0f;
    float timeLimit = 2f;

    void Update() {
        timer += Time.deltaTime;

        if (timer >= timeLimit) {
            Destroy(gameObject);
        }
    }
}
