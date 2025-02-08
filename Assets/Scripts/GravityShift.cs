using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GravityShift : MonoBehaviour
{
    public GameObject parent;
    private float RotationSpeed = 90f;
    private float TargetLocation = 90f;
    private float CurrentRotation = 0f;
    private bool isRotating = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            isRotating = true;
        }

        if (isRotating)
        {
            float step = RotationSpeed * Time.deltaTime;

            if (CurrentRotation + step > TargetLocation)
            {
                step = TargetLocation - CurrentRotation;
                isRotating = false;
                CurrentRotation = 0;
            }
            transform.Rotate(0, 0, step);
            CurrentRotation += step;
        }
    }
}
