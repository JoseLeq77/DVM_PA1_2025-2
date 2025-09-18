using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float directionX;
    private float directionZ;
    public float moveSpeed = 5f;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float raycastDistance;

    private bool _canJump = false;

    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        velocity = new Vector3(directionX * moveSpeed, rb.linearVelocity.y, directionZ * moveSpeed);
        rb.linearVelocity = velocity;

        bool RaycastDetection = Physics.Raycast(transform.position, Vector3.down, raycastDistance, groundLayers);

        if (RaycastDetection)
        {
            _canJump = true;
            Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.green);
        }
        else
        {
            _canJump = false;
            Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);
        }
    }

    public void OnXMovement(InputAction.CallbackContext context)
    {
        directionX = context.ReadValue<float>();
    }
    public void OnZMovement(InputAction.CallbackContext context)
    {
        directionZ = context.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _canJump)
        {
            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
            }
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } 
    }
    public void ModifyCanJump(bool b)
    {
        _canJump = b;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("limit"))
        {
            gameManager.GameOver();
        }
        if (other.CompareTag("goal"))
        {
            gameManager.WinGame();
        }
    }
}
