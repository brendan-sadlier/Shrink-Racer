using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPickUp : MonoBehaviour
{
    public float rotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpController player = other.GetComponent<PickUpController>();

            if (player != null)
            {
                player.ActivateTurret();
            }
            else
            {
                Debug.LogError("Player is null");
            }
            Destroy(this.gameObject);
        }
    }
}
