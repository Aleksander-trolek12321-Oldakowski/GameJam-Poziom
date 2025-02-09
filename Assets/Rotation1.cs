using System.Collections;
using UnityEngine;

public class Rotation1 : MonoBehaviour
{
    public Transform parent;
    public float rotationSpeed = 90f;
    private bool isRotating = false;
    private bool playerInZone = false;
    public GameObject ParentWysp;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRotating)
        {
            playerInZone = true;

            StartCoroutine(RotateParent());
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