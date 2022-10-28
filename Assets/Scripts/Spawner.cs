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
    [SerializeField] float difficultyIncrease;

    [SerializeField] float upperSpawnTime;
    [SerializeField] float lowerSpawnTime;
    float spawnTimer;
    float difficultyTimer;
    int ballCounter;
    [SerializeField] int ballLimit;
    [SerializeField] int maxBallLimit;
    bool maxReached = false;

    // Start is called before the first frame update
    void Start() {
        maxReached = false;
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
        spawnTimer += Time.deltaTime;
        difficultyTimer +=  Time.deltaTime;
        
        if (spawnTimer >= spawnTime) {
            spawnTimer = 0;
            ResetSpawnTime();

            if (ballCounter < ballLimit) { // Only allow a certain # of balls on screen at once
                SpawnBall();
            }
        }

        if (difficultyTimer >= difficultyIncrease && !maxReached) {
            IncreaseDifficulty();
        }
    }

    void IncreaseDifficulty() {
        if (ballLimit < maxBallLimit) {
            ballLimit += 1;
        } else {
            maxReached = true;
        }
        
        difficultyTimer = 0;
    }

    public void EndGame() { // Stops the spawning of all balls, and destroys all current ones
        ballCounter = 100;

        foreach (Transform child in gameObject.transform) {
            Destroy(child.gameObject);
        }
    }
}
