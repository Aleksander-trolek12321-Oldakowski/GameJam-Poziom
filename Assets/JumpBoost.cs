using Unity.VisualScripting;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    private bool PlayerInZone;
    public GameObject Player;
    public bool EventForward;
    private Controls jumpHeight;
    private Controls moveSpeed;
    void Start()
    {
        PlayerInZone = false;
        EventForward = false;
    }


    private void OnValidate()
    {
        EventForward = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((PlayerInZone) && EventForward)
        {
            jumpHeight = GetComponent<Controls>();
            jumpHeight.jumpHeight = 4f;
            moveSpeed.moveSpeed = 7f;
        } 
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInZone = false;
        }
    }
}