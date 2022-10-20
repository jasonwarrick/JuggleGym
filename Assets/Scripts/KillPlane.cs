using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlane : MonoBehaviour
{
    [SerializeField] GameObject spawner;

    [SerializeField] AudioSource killAudio;
    [SerializeField] AudioSource lazerAudio;
    [SerializeField] ParticleSystem deathParticles;
    Quaternion particleRotation = Quaternion.Euler(-90, 0, 0);

    void OnCollisionEnter2D(Collision2D other) {
        killAudio.Play();
        lazerAudio.Play();
        
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            spawner.GetComponent<Spawner>().Die();
        }
        
        Destroy(other.transform.gameObject);

        Vector3 oldPostion = other.gameObject.transform.position;
        Vector3 newPosition = new Vector3(oldPostion.x, transform.position.y, 0f);

        Instantiate(deathParticles, newPosition, particleRotation);
    }
}
