using UnityEngine;

// https://docs.unity3d.com/ScriptReference/Collision-gameObject.html
public class PlayerCollision : MonoBehaviour
{

    DestructablePlayer destructablePlayer;
    public AudioSource audioSource;

    public GameObject player;
    PlayerMovement playerMovement;


    void Start()
    {
        destructablePlayer = GetComponent<DestructablePlayer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle!");
            destructablePlayer.DestroyPlayer();
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collisionInfo.collider.tag == "EnemyBullet")
        {
            Debug.Log("We hit an enemy!");
            destructablePlayer.DestroyPlayer();
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collisionInfo.collider.tag == "EnemyTurret")
        {
            Debug.Log("We hit an enemy turret");
            destructablePlayer.DestroyPlayer();
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collisionInfo.collider.tag == "Road")
        {
            Debug.Log("We hit a road!");
        }
    }
    

}