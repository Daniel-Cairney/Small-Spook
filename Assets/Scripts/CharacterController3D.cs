using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float groundCheckDistance = 1.1f;
    public LayerMask groundLayer;

    public Transform cameraTransform;  // Optional, for camera-aligned movement
    public float mouseSensitivity = 2f;

    private Rigidbody rb;
    private Vector3 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get movement input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        input = new Vector3(horizontal, 0, vertical).normalized;

        // Mouse look (Y handled by separate CameraLook script)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Vector3 move = transform.TransformDirection(input) * moveSpeed;
        Vector3 velocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        // If no input, stop horizontal movement immediately
        if (input.magnitude == 0)
        {
            velocity.x = 0;
            velocity.z = 0;
        }

        rb.linearVelocity = velocity;
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // Cancel current vertical velocity
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}
