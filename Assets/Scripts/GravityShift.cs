using System.Collections;
using UnityEngine;

public class GravityShift : MonoBehaviour
{
    public Transform parent; // Obiekt, kt�ry ma by� obracany
    public float rotationSpeed = 90f; // Szybko�� obrotu w stopniach na sekund�
    private bool isRotating = false;
    private bool playerInZone = false;
    public Rigidbody playerRb;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRotating)
        {
            playerInZone = true;
            playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                playerRb.useGravity = false; // Wy��cz grawitacj� gracza
                playerRb.linearVelocity = Vector3.zero; // Zatrzymaj ruch gracza
            }

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
                step = 90f - rotatedAmount; // Dok�adnie doko�cz obr�t do 90 stopni
            }

            parent.Rotate(0, 0, step);
            rotatedAmount += step;
            yield return null;
        }

        if (playerRb != null)
        {
            playerRb.useGravity = true; // Przywr�� grawitacj� gracza
        }

        isRotating = false;
    }
}
