using UnityEngine;

public class BulletPickUp : MonoBehaviour
{

    public float rotationSpeed = 100f;
    public int bulletIncrease = 10;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }
}
