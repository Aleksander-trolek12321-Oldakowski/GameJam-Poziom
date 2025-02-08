using System.Collections;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab kulki
    public Transform spawnPoint;  // Punkt, w którym będą się pojawiać kule
    public float spawnInterval = 1f; // Co ile sekund ma się pojawiać nowa kula
    public float ballSpeed = 5f; // Prędkość kuli

    private float timer;

    void Update()
    {
        // Odliczanie czasu do spawnu nowej kuli
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Spawner();
            timer = 0f;
        }
    }

    void Spawner()
    {
        // Tworzenie nowej kuli w miejscu spawnPoint
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);

        // Nadanie prędkości kuli w prawo (można zmienić kierunek)
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.linearVelocity = Vector3.right * ballSpeed;
        }
    }
}
