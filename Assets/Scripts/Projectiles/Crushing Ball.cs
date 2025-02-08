using UnityEngine;

public class CrushingBall : MonoBehaviour
{
    public GameObject gameObject;
    public LayerMask Player;
    public GameObject player;
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    
    private void OnCollisionEnter(Collision other) 
    {
        Destroy(gameObject);
    }

}
