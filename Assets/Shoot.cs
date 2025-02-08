using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 1f;
    public float ballSpeed = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawner();
            timer = 0f;
        }
    }

    void Spawner()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.linearVelocity = Vector3.right * ballSpeed;
        }
    }
}