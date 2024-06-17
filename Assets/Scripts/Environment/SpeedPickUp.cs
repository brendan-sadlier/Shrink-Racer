using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickUp : MonoBehaviour
{
    public float speedBoost = 100f;
    public float duration = 2f;

    public IEnumerator BoostSpeed(PlayerMovement player)
    {
        player.sideSpeed += speedBoost;
        player.forwardSpeed += speedBoost;

        yield return new WaitForSeconds(duration);

        player.sideSpeed -= speedBoost;
        player.forwardSpeed -= speedBoost;
    }
}
