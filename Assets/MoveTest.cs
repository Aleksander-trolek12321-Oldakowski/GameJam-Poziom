using UnityEngine;
using System.Collections;

public class MoveTest : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;
    public Animator animator;
    private Vector3 startPosition;
    private bool movingRight = true;

    private void Awake()
    {
        animator.SetBool("isWalking", true);
    }
    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        Vector3 targetPosition = movingRight ? startPosition + Vector3.right * moveDistance : startPosition - Vector3.right * moveDistance;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            movingRight = !movingRight;
        }
    }
}
