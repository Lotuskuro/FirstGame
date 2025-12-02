using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Player Settings")]
    [SerializeField] private float MovementSpeed = 5.0f;
    [SerializeField] private float JumpHeight = 2.0f;
    private Vector3 moveInput;
    private Vector3 jumpInput;
    private Vector3 horizontalMove;
    private Vector3 dashDirection;
    private float gravity = -9.80f;

    [Header("Dash Settings")]
    [SerializeField] private float DashDistance = 6.0f;
    [SerializeField] private float dashCooldown = 1.0f;
    private float dashDuration = 0.2f;
    private float dashTimer;
    private float dashTime;
    private bool isDashing;

    void Start()
    {
        dashTimer = dashCooldown;
        characterController = GetComponent<CharacterController>();

    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

    }
    public void Jump(InputAction.CallbackContext context) 
    {
        if(context.performed && characterController.isGrounded)
        {
            jumpInput.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        
        if (dashTimer < dashCooldown)
            return;

        Vector3 inputDir = new Vector3(moveInput.x, 0f, moveInput.y);
        dashDirection = inputDir.sqrMagnitude > 0.001f ? inputDir.normalized : transform.forward;

        isDashing = true;
        dashTime = dashDuration;
        dashTimer = 0f;
    }

        void Update()
    {
        dashTimer += Time.deltaTime;
        if (isDashing)
        {
            float dashspeed = DashDistance / Mathf.Max(0.01f, dashDuration);
            horizontalMove = dashDirection * dashspeed;

            dashTime -= Time.deltaTime;
            if (dashTime <= 0f)
            {
                isDashing = false;
            }
        }
        else
        {
            horizontalMove = new Vector3(moveInput.x, 0, moveInput.y) * MovementSpeed;
        }

        jumpInput.y += gravity * Time.deltaTime;

        Vector3 finalMove = horizontalMove + new Vector3(0, jumpInput.y, 0);
        characterController.Move(finalMove * Time.deltaTime);

    }
    }

   

