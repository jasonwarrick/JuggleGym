using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    [SerializeField] GameObject spawner;

    void OnCollisionEnter2D(Collision2D other) {
        spawner.GetComponent<Spawner>().Die();
        Destroy(other.transform.parent.gameObject);
    }
}
