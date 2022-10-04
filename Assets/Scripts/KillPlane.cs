using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlane : MonoBehaviour
{
    [SerializeField] GameObject spawner;

    void OnCollisionEnter2D(Collision2D other) {
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            spawner.GetComponent<Spawner>().Die();
        }
        
        Destroy(other.transform.parent.gameObject);
    }
}
