using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    public Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;    
    }
}
