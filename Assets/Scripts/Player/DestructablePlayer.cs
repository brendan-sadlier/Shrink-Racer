using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=EgNV0PWVaS8
public class DestructablePlayer : MonoBehaviour
{

    public GameObject destroyedCarPrefab;

    public void DestroyPlayer ()
    {
        Instantiate(destroyedCarPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
