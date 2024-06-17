using UnityEngine;

public class GasCanPickup : MonoBehaviour
{
    public float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        // Set Prefabs Initial Y Position
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        // Set Prefabs Initial Rotation
        transform.rotation = Quaternion.Euler(-90, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Credit: https://discussions.unity.com/t/animate-a-cube-rotation-with-script-only/68570/2
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
