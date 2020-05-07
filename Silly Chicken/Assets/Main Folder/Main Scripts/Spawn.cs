using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;
    public GameObject enemy;
    public Transform[] spawnPoints;

    private void Awake()
    {
        StartCoroutine(WaitToSpawn());
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WaitToSpawn();
        }
    }

    public void callSpawn()
    {
        StartCoroutine(WaitToSpawn());
    }

    public void Spawning()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, Quaternion.identity);
    }

    public IEnumerator WaitToSpawn()
    {
        Debug.Log("Spawn");
        yield return new WaitForSeconds(4f);
        Debug.Log("Waited");
        Spawning();
    }
}
