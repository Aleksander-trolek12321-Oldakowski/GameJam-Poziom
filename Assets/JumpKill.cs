using UnityEngine;

public class JumpKill : MonoBehaviour
{
    private bool PlayerOnTop;
    public GameObject enemy;

    private void Start()
    {
        PlayerOnTop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!PlayerOnTop && other.CompareTag("Player"))
        {
            PlayerOnTop=true;
            enemy.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
