using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform[] spawnPoints;
    public float numOfBalls;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(numOfBalls.ToString());
        StartCoroutine(SpawnBalls());
      
    }

    IEnumerator SpawnBalls()
    {
        while (numOfBalls > 0)
        {
            yield return new WaitForSeconds(0.1f);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedBall = Instantiate(ballPrefab, spawnPoint.position, transform.rotation);
            Debug.Log(numOfBalls.ToString());
            numOfBalls--;
        }
    }
}
