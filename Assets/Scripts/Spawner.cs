using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject parentGameObject;
    [SerializeField] GameObject scoreHandler;
    
    float topOfScreen = 6f;
    float spawnTime = 1f;

    [SerializeField] float upperSpawnTime;
    [SerializeField] float lowerSpawnTime;
    float timer;
    int ballCounter;
    [SerializeField] int ballLimit = 5;

    // Start is called before the first frame update
    void Start() {
        ballCounter = 0;
        spawnTime = 1f; // The first ball is always dropped after one second
    }

    void ResetSpawnTime() {
        spawnTime = Random.Range(lowerSpawnTime, upperSpawnTime);
    }

    void SpawnBall() {
        ballCounter++;
        Vector3 position = new Vector3(Random.Range(-8f, 8f), topOfScreen, 0); // Randomize horizontal position
        GameObject ballInstance = Instantiate(ball, position, Quaternion.identity);
        ballInstance.transform.parent = parentGameObject.transform; // Spawn every ball as a child of BallSpawner
    }

    public void Hit(float yPos) {
        scoreHandler.GetComponent<ScoreHandler>().IncreaseScore(yPos);
    }

    public void Die() {
        ballCounter--;
        scoreHandler.GetComponent<ScoreHandler>().DamageHealth();
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        
        if (timer >= spawnTime) {
            timer = 0;
            ResetSpawnTime();

            if (ballCounter < ballLimit) { // Only allow 5 balls on screen at once
                SpawnBall();
            }
        }
    }
}
