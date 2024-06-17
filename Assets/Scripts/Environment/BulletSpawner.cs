using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField] private GameObject bulletPickUpPrefab;
    [SerializeField] private Vector2 minMaxXPos;
    [SerializeField] private float baseSpawnZLocation = 120f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float startZSpawn = 125f;
    [SerializeField] private Vector2 spawnZDistanceVariation = new Vector2(-10f, 10f);

    private float lastSpawnZPos = 0;
    private float delay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        lastSpawnZPos = startZSpawn - baseSpawnZLocation;
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(delay);

        while (true)
        {
            SpawnBulletPickUp();
            yield return new WaitForSeconds(delay);
        }
    }

    private void SpawnBulletPickUp()
    {
       if (bulletPickUpPrefab == null) return;

        Vector3 spawnPosition = CalculateSpawnPosition();
        Instantiate(bulletPickUpPrefab, spawnPosition, bulletPickUpPrefab.transform.rotation);
    }

    private Vector3 CalculateSpawnPosition()
    {
        float xPos = Random.Range(minMaxXPos.x, minMaxXPos.y);
        float zPosOffset = Random.Range(spawnZDistanceVariation.x, spawnZDistanceVariation.y);
        float zPos = Mathf.Max(playerTransform.position.z + baseSpawnZLocation + zPosOffset);

        lastSpawnZPos = zPos;

        return new Vector3(xPos, bulletPickUpPrefab.transform.position.y, zPos);
    }
}
