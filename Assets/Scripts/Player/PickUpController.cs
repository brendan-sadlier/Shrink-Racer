using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject turret;
    public GameObject turretActive;

    public void ActivateTurret()
    {
        if (turretActive == null)
        {
            Transform attachmentPoint = transform.Find("TurretAttachmentPoint");

            if (attachmentPoint != null)
            {
                turretActive = Instantiate(turret, attachmentPoint.position, Quaternion.identity, attachmentPoint);
            }
            else
            {
                Debug.LogError("No attachment point found");
            }
        }
    }
}
