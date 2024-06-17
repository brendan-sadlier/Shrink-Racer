using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: https://www.youtube.com/watch?v=HIsEqKPoJXM
public class TrackSpawner : MonoBehaviour
{

    public GameObject trackPrefab;
    public Transform player;
    public float zSpawn = 0;

    private float trackLength = 40f;
    private int numberOfTracksOnScreen = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < numberOfTracksOnScreen; i++)
        {
            SpawnTrack();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > (zSpawn - numberOfTracksOnScreen * trackLength))
        {
            SpawnTrack();
        }
    }

    void SpawnTrack()
    {
        GameObject track = Instantiate(trackPrefab) as GameObject;
        track.transform.SetParent(transform);
        track.transform.position = Vector3.forward * zSpawn;
        zSpawn += trackLength;
    }
}
