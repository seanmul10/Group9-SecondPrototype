using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleSpawns : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject prefab;

    float nextActionTime = 0.0f;
    public float period = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            SpawnEnemyAtPoint();
        }
		
	}

    void SpawnEnemyAtPoint()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length); // a random spawnpoint is chosen
        Instantiate(prefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation); // spawns a prefab (barrel) in the position of the spawnpoint
    }
}
