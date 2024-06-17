using UnityEngine;


// https://www.youtube.com/watch?v=KOk5mHdcooA
public class EnemyTurretController : MonoBehaviour
{

    Transform target;
    public float range = 15f;
    public float currentDistanceToTarget;
    public Transform canon;
    public GameObject bulletPrefab;
    public Transform shootPoint;

    public AudioSource[] audioSources;

    public float fireRate, nextFire;

    DestructableEnemy destructableEnemy;

    // Start is called before the first frame update
    void Start()
    {

        destructableEnemy = GetComponent<DestructableEnemy>();

        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
        PlaySound(0);
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(shootPoint.forward * 1000);
        Destroy(bullet, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "PlayerBullet")
        {
            PlaySound(1);
            Debug.Log("We hit an enemy turret");
            destructableEnemy.DestroyEnemy();
        }
    }

    private void PlaySound(int index)
    {
        audioSources[index].Play();
    }
}
