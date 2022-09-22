using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ball;

    float topOfScreen = 6f;
    float spawnTime = 5f;
    float timer;

    // Start is called before the first frame update
    void Start() {
        
    }

    void SpawnBall() {
        Vector3 position = new Vector3(Random.Range(-8f, 8f), topOfScreen, 0);
        Instantiate(ball, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        
        if (timer >= spawnTime) {
            SpawnBall();
            timer = 0;
        }
    }
}
