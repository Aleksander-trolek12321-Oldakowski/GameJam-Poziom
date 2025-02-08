using UnityEngine;

public class JumpKill : MonoBehaviour
{
    private bool PlayerOnTop;
    public GameObject enemy;
    public Animator animator;

    private void Start()
    {
        PlayerOnTop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!PlayerOnTop && other.CompareTag("Player"))
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isDead", true);
            PlayerOnTop=true;
            Destroy(enemy, 2f);
        }

    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
