using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerMove2 : MonoBehaviour
{
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float animDampTime = 0.15f;
    [SerializeField] float smoothTime = 0.05f;

    Vector2 playerMoveInput;
    float currentVelocity;

    CharacterController characterController;
    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerMoveInput = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        Vector3 moveInput = (new Vector3(playerMoveInput.x, 0, playerMoveInput.y)).normalized;
        float moveAmount = Mathf.Abs(playerMoveInput.x) + Mathf.Abs(playerMoveInput.y);

        // Movement
        characterController.Move(moveInput * walkSpeed * Time.deltaTime);

        if (moveAmount > 0)        // Walking
        {
            if (Input.GetKey(KeyCode.C))        // Aiming while moving
            {
                moveAmount = 2;
            }
            if (Input.GetKey(KeyCode.E))        // Shoot While moving
            {
                moveAmount = 3;
            }

            // Rotation
            var targetAngle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }
        else        // Idle
        {
            if (Input.GetKey(KeyCode.C))        // Aiming While Idle
            {
                moveAmount = -1;
            }
            if (Input.GetKey(KeyCode.E))        // Shoot while Idle
            {
                moveAmount = -2;
            }
        }

        // Set Animation
        anim.SetFloat("ErikaMoveVal", moveAmount, animDampTime, Time.deltaTime);
    }
}
