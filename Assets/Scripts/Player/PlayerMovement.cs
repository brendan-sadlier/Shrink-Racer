using System.Collections;
using DG.Tweening;
using UnityEngine;

// https://dotween.demigiant.com/documentation.php#creatingTweener
public class PlayerMovement : MonoBehaviour
{

    private float distanceTraveled = 0;

    private Rigidbody rb;
    [SerializeField] private Joystick joystick;
    public float sideSpeed = 600f;
    public float forwardSpeed = 600f;

    public Vector2 boundary;

    // For Scaling
    private float scaleDuration = 10f;
    private float scaleFactor = -1.2f;
    private float maxScale = 1f;
    private float currentScale;

    DestructablePlayer destroyedPlayer;
    Bullets bulletsDisplay;
    SpeedPickUp speedPickUp;
    public FuelBar fuelBar;

    public AudioSource[] audioSources;

    // 
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        destroyedPlayer = GetComponent<DestructablePlayer>();
        currentScale = maxScale;
        fuelBar.SetMaxFuel(maxScale);
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(new Vector3(0, 0, 0), scaleDuration);
        bulletsDisplay = GameObject.Find("BulletDisplay").GetComponent<Bullets>();

    }

    void FixedUpdate ()
    {

        currentScale = transform.localScale.x;

        float adjustedMinX = boundary.x + (1 - currentScale) * scaleFactor;
        float adjustedMaxX = boundary.y - (1 - currentScale) * scaleFactor;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, adjustedMinX, adjustedMaxX), 
            0, 
            transform.position.z
        );
        
        rb.velocity = new Vector3(
            joystick.Horizontal * sideSpeed * Time.deltaTime, 
            rb.velocity.y, 
            forwardSpeed * Time.deltaTime
        );

        if (transform.localScale.x <= 0.25f)
        {
            DOTween.Kill(transform);
            destroyedPlayer.DestroyPlayer();
            FindObjectOfType<GameManager>().EndGame();
        }

        fuelBar.SetFuel(currentScale);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "GasCan")
        {
            PlaySound(0);
            Debug.Log("We hit a gas can!");
            Destroy(collider.gameObject);
            DOTween.Kill(transform);
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f)
                .OnComplete(() => {
                    transform.DOScale(new Vector3(0, 0, 0), scaleDuration);
                });
        }

        if (collider.tag == "SpeedPickUp")
        {
            PlaySound(1);
            SpeedPickUp speedPickUp = collider.gameObject.GetComponent<SpeedPickUp>();
            StartCoroutine(speedPickUp.BoostSpeed(this));
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("BulletPickUp"))
        {
            PlaySound(2);
            BulletPickUp bulletPickUp = collider.gameObject.GetComponent<BulletPickUp>();
            TurretController turretController = GetComponentInChildren<TurretController>();

            if (bulletPickUp == null)
            {
                Debug.LogError("BulletPickUp is null");
                return;
            }

            if (turretController == null)
            {
                Debug.LogError("TurretController is null");
                return;
            }
            
            turretController.bulletCount += bulletPickUp.bulletIncrease;
            Debug.Log("Bullet count: " + turretController.bulletCount);
            bulletsDisplay.AddBullets(bulletPickUp.bulletIncrease);
            Destroy(collider.gameObject);
        }
    }

    public void PlaySound(int index)
    {
        audioSources[index].Play();
    }
}
