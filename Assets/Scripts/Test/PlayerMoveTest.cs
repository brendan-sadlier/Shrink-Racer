using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{

    public float forwardSpeed = 600f;
    [SerializeField] private Joystick joystick;
    
    public float sideSpeed = 600f;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -5.25f, 5.25f), 
            0, 
            transform.position.z
        );
        
        rb.velocity = new Vector3(
            joystick.Horizontal * sideSpeed * Time.deltaTime, 
            rb.velocity.y, 
            forwardSpeed * Time.deltaTime
        );
    }
}
