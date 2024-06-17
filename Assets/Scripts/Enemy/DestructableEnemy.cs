using UnityEngine;

public class DestructableEnemy : MonoBehaviour
{

    public GameObject destroyedEnemyPrefab;

    public void DestroyEnemy()
    {
        GameObject destroyedInstance = Instantiate(destroyedEnemyPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(destroyedInstance, 0.5f);
    }
}
