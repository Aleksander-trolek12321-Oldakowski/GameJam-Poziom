using UnityEngine;

public class Controls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;
    public float jumpHeight = 2f;
    public float gravity = 9.81f;
    public int maxJumps = 2;
    public float dashForce = 10f;
    public float dashDuration = 0.2f;
    
    public Transform cameraTransform;
    public Vector3 cameraOffset = new Vector3(0, 2, -4);
    
    private CharacterController controller;
    private float verticalVelocity;
    private int jumpCount = 0;
    private float yaw = 0f;
    private float pitch = 0f;
    private bool isDashing = false;
    private bool hasDashed = false;
    private float dashTimer = 0f;
    
    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        MovePlayer();
        RotateCamera();
        
        // Obsługa dashu
        if (Input.GetKeyDown(KeyCode.LeftShift) && !controller.isGrounded && !hasDashed)
        {
            StartDash();
        }
        
        // Aktualizacja dashu
        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        }
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
        
        // Animacja chodzenia
        if (moveX != 0 || moveZ != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            jumpCount = 0;
            hasDashed = false;
            
            // Animacja skoku
            animator.SetBool("IsJumping", false);
            
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = Mathf.Sqrt(jumpHeight * 2f * gravity);
                jumpCount++;
                animator.SetBool("IsJumping", true);
            }
        }
        else if (jumpCount < maxJumps && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * 2f * gravity);
            jumpCount++;
            animator.SetBool("IsJumping", true);
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        if (isDashing)
        {
            move = transform.forward * dashForce;
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
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 newPosition = transform.position + rotation * cameraOffset;
        
        cameraTransform.position = newPosition;
        cameraTransform.LookAt(transform.position + Vector3.up * 1.5f);
    }
    
    void StartDash()
    {
        isDashing = true;
        hasDashed = true;
        dashTimer = dashDuration;
    }
}