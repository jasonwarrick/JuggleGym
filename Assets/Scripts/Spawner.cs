using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject parentGameObject;
    [SerializeField] GameObject scoreHandler;
    
    float topOfScreen = 6f;
    float spawnTime = 5f;
    float timer;

    // Start is called before the first frame update
    void Start() {
        SpawnBall();
    }

    void SpawnBall() {
        Vector3 position = new Vector3(Random.Range(-8f, 8f), topOfScreen, 0);
        GameObject ballInstance = Instantiate(ball, position, Quaternion.identity);
        ballInstance.transform.parent = parentGameObject.transform; // Spawn every ball as a child of BallSpawner
    }

    public void Hit() {
        scoreHandler.GetComponent<ScoreHandler>().IncreaseScore();
    }

    public void Die() {
        scoreHandler.GetComponent<ScoreHandler>().DecreaseScore();
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
