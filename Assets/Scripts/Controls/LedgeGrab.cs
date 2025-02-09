using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class LedgeGrab : MonoBehaviour
{
    public float grabRange = 1f;
    public float ledgeCheckHeight = 0.5f;
    public float climbSpeed = 2f;
    public LayerMask environmentLayer;

    private CharacterController controller;
    private bool isClimbing = false;
    private Vector3 ledgePosition;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isClimbing && !controller.isGrounded)
        {
            CheckForLedge();
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("joystick button 9") && !isClimbing)
        {
            TryGrabLedge();
        }
    }

    void CheckForLedge()
    {
        Vector3 origin = transform.position + Vector3.up * ledgeCheckHeight;
        RaycastHit hit;

        // Sprawdź czy przed graczem jest ściana/platforma
        if (Physics.Raycast(origin, transform.forward, out hit, grabRange, environmentLayer))
        {
            // Sprawdź czy pod krawędzią jest pusta przestrzeń
            if (!Physics.Raycast(hit.point + Vector3.up * 0.1f, Vector3.down, 0.5f, environmentLayer))
            {
                ledgePosition = hit.point;
            }
        }
    }

    void TryGrabLedge()
    {
        if (Vector3.Distance(transform.position, ledgePosition) < grabRange * 1.5f)
        {
            StartCoroutine(ClimbLedge());
        }
    }

    IEnumerator ClimbLedge()
    {
        isClimbing = true;
        controller.enabled = false;

        Vector3 startPos = transform.position;
        Vector3 endPos = ledgePosition + Vector3.up * 1.5f - transform.forward * 0.2f;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * climbSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        controller.enabled = true;
        isClimbing = false;
    }
}
