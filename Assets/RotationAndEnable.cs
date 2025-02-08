using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class RotationAndEnable : MonoBehaviour
{
    public GameObject island1;
    public GameObject island2;
    public GameObject island3;
    public Transform parent;
    public float rotationSpeed = 90f;
    private bool isRotating = false;
    private bool playerInZone = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRotating)
        {
            playerInZone = true;

            island1.SetActive(true);
            island2.SetActive(true);
            island3.SetActive(true);
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
