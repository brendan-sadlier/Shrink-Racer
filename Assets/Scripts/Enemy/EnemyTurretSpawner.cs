using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyTurretPrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnZDistance = 100f;

    public const float maxXPos = 12.15f;
    public const float minXPos = -12.15f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyTurret());
    }

    private IEnumerator SpawnEnemyTurret()
    {
        while (true) // Infinite loop
        {
            SpawnTurretAtRandomPos();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnTurretAtRandomPos()
    {
        float randomXPosition = Random.Range(minXPos, maxXPos + 1); // +1 to include the max position in the range
        Vector3 spawnPosition = new Vector3(randomXPosition, 0, playerTransform.position.z + spawnZDistance);

        Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);

        Instantiate(enemyTurretPrefab, spawnPosition, spawnRotation);
    }
}
