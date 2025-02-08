using UnityEngine;

public class MP_UD : MonoBehaviour
{
    public float speed = 2f;
    public float height = 3f;

    private bool movingUp = true;

    void Update()
    {
        float newY = transform.position.y + (movingUp ? speed : -speed) * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        if (movingUp && transform.position.y >= height)
        {
            movingUp = false;
        }
        else if (!movingUp && transform.position.y <= 0)
        {
            movingUp = true;
        }
    }
}
