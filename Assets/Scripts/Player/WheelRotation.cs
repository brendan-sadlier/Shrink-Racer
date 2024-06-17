using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public GameObject[] wheels;
    public Rigidbody carRigidbody;

    private float wheelCircumference = 2f;

    // Update is called once per frame
    void Update()
    {
        RotateWheels();
    }

    void RotateWheels()
    {
        float distance = carRigidbody.velocity.magnitude * Time.deltaTime;
        float rotation = (distance / wheelCircumference) * 360;

        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(Vector3.right, rotation);
        }
    }
}
