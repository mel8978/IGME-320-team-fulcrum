using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpSpeed = 7f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] Vector2 lookSens = new Vector2(0.1f, 0.1f); // degrees per mouse pixel
    [SerializeField] LayerMask groundLayer;      // must NOT include the player's own layer
    [SerializeField] float groundCheckDistance = 1.1f; // capsule half-height + small margin

    Camera myCamera;
    Rigidbody rb;
    Vector2 moveInput;
    float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    void FixedUpdate()
    {
        Vector3 move = (transform.forward * moveInput.y + transform.right * moveInput.x) * moveSpeed;
        Vector3 vel = rb.linearVelocity;          // use rb.velocity on pre-Unity 6
        vel.x = move.x;
        vel.z = move.z;

        if (vel.y < 0) // falling: stronger gravity
            vel.y += Physics.gravity.y * (fallMultiplier - 1f) * Time.fixedDeltaTime;

        rb.linearVelocity = vel;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 look = context.ReadValue<Vector2>();

        transform.Rotate(0f, look.x * lookSens.x, 0f);

        pitch = Mathf.Clamp(pitch - look.y * lookSens.y, -89f, 89f);
        myCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().normalized;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            Vector3 vel = rb.linearVelocity;
            vel.y = jumpSpeed;
            rb.linearVelocity = vel;
        }
    }
}