using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUpSpawner : MonoBehaviour
{

    [SerializeField] private GameObject speedPickUpPrefab;
    [SerializeField] private Vector2 minMaxXPos;
    [SerializeField] private float spawnZDistanceAhead = 100f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float startZSpawn = 125f;

    private float lastSpawnZPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnZPos = startZSpawn - spawnZDistanceAhead;
        StartCoroutine(SpawnSpeedPickUp());
    }

    private IEnumerator SpawnSpeedPickUp()
    {
        while (true)
        {
            yield return new WaitUntil(() => playerTransform.position.z > lastSpawnZPos - 10);

            Vector3 spawnPos = new Vector3(
                Random.Range(minMaxXPos.x, minMaxXPos.y),
                speedPickUpPrefab.transform.position.y,
                Mathf.Max(playerTransform.position.z + spawnZDistanceAhead + Random.Range(-2f, 2f), lastSpawnZPos + spawnZDistanceAhead)
            );

            Instantiate(speedPickUpPrefab, spawnPos, Quaternion.identity);

            lastSpawnZPos = Mathf.Max(playerTransform.position.z + spawnZDistanceAhead, spawnPos.z);

            yield return new WaitForSeconds(2f);
        }
    }
}
