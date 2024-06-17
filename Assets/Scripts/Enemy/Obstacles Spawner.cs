using System.Collections;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnZDistance = 100f;

    public const float maxXPos = 12.15f;
    public const float minXPos = -12.15f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        while (true) // Infinite loop
        {
            SpawnObstacleAtRandomPosition();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // https://docs.unity3d.com/Manual/InstantiatingPrefabs.html
    private void SpawnObstacleAtRandomPosition()
    {
        float randomXPosition = Random.Range(minXPos, maxXPos + 1); // +1 to include the max position in the range
        Vector3 spawnPosition = new Vector3(randomXPosition, 0, playerTransform.position.z + spawnZDistance);

        Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);

        Instantiate(obstaclePrefab, spawnPosition, spawnRotation);
    }
}
