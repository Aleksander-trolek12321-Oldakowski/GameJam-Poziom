using UnityEngine;

public class Controls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;
    public float jumpHeight = 2f;
    public float gravity = 9.81f;
    public int maxJumps = 2;
    
    public Transform cameraTransform;
    public Vector3 cameraOffset = new Vector3(0, 2, -4); // Pozycja kamery za graczem
    
    private CharacterController controller;
    private float verticalVelocity;
    private int jumpCount = 0;
    private float yaw = 0f; // Kąt obrotu poziomego
    private float pitch = 0f; // Kąt obrotu pionowego
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        MovePlayer();
        RotateCamera();
    }
    
    void LateUpdate()
    {
        UpdateCameraPosition();
    }
    
    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            jumpCount = 0;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2f * gravity);
                jumpCount++;
            }
        }
        else if (jumpCount < maxJumps && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * 2f * gravity);
            jumpCount++;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        move.y = verticalVelocity;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
    
    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -45f, 45f);
        
        transform.rotation = Quaternion.Euler(0, yaw, 0);
    }
    
    void UpdateCameraPosition()
    {
        // Oblicz nową pozycję kamery z uwzględnieniem obrotu w pionie
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 newPosition = transform.position + rotation * cameraOffset;
        
        cameraTransform.position = newPosition;
        cameraTransform.LookAt(transform.position + Vector3.up * 1.5f);
    }
}