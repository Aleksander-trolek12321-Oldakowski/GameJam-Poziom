using System.Collections;
using UnityEngine;

public class EndRotation : MonoBehaviour
{
    public Transform parent;
    public GameObject block;
    public float rotationSpeed = 90f;
    private bool isRotating = false;
    private bool playerInZone = false;
    public GameObject AchievmentSource;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRotating)
        {
            playerInZone = true;
            AchievmentSource.SetActive(true);
            StartCoroutine(RotateParent());

            block.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }

    IEnumerator RotateParent()
    {
        isRotating = true;
        float rotatedAmount = 0f;

        while (rotatedAmount < 90f)
        {
            float step = rotationSpeed * Time.deltaTime;
            if (rotatedAmount + step > 90f)
            {
                step = 90f - rotatedAmount;
            }

            parent.Rotate(0, 0, step);
            rotatedAmount += step;
            yield return null;
        }

        isRotating = false;
    }
}