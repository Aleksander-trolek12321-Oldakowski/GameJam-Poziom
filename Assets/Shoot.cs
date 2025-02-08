using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float ballSpeed = 5f;
    public Animator animator;

    private bool isShooting = false;

    void Update()
    {
        if (!isShooting)
        {
            StartCoroutine(ShootAfterAnimation());
        }
    }

    private IEnumerator ShootAfterAnimation()
    {
        isShooting = true;
        animator.SetBool("isShooting", true);

        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength / 2);

        // Wystrzel pocisk w połowie animacji
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.linearVelocity = Vector3.left * ballSpeed;
        }

        yield return new WaitForSeconds(animationLength / 2);
        
        animator.SetBool("isShooting", false);
        isShooting = false;
    }
}