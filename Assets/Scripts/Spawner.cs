using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Rigidbody2D player;
    private float nextPickupPosition;
    private float nextGroundObstaclePosition;
    private float nextBalloonPosition;
    public GameObject[] pickups;
    public GameObject[] groundObstacles;
    public GameObject balloon;

    private void Start()
    {
        nextPickupPosition = Random.Range(15, 25);
        nextGroundObstaclePosition = Random.Range(100, 1000);
        nextBalloonPosition = Random.Range(20, 100);
    }

    private void Update()
    {
        ManagePickups();
        ManageObstacles();
        ManageBalloons();
    }

    void Spawn(GameObject[] objects, float yPosition, float xPosition)
    {
        Instantiate(objects[Random.Range(0, objects.Length)], new Vector2(transform.position.x + xPosition, yPosition), Quaternion.identity);
    }

    void ManagePickups()
    {
        if (transform.position.x > nextPickupPosition)
        {
            Spawn(pickups, Mathf.Max(transform.position.y + Random.Range(-5, 5), -2.2f), 20);
            nextPickupPosition += Random.Range(Mathf.Clamp(2, player.velocity.x * 0.35f, 30), Mathf.Clamp(30, player.velocity.x * 1.5f, 100));
        }
    }

    void ManageObstacles()
    {
        if (transform.position.x > nextGroundObstaclePosition)
        {
            Spawn(groundObstacles, -4.18f, 100);
            nextGroundObstaclePosition += Random.Range(30, 400);
        }
    }

    void ManageBalloons()
    {
        if (transform.position.x > nextBalloonPosition)
        {
            Instantiate(balloon, new Vector2(transform.position.x + 20, Mathf.Max(transform.position.y + Random.Range(-15, 5), -3.90f)), Quaternion.identity);
            nextBalloonPosition += Random.Range(2, 100);
        }
    }
}
