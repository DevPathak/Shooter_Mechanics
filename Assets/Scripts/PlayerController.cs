using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;

    public float mouseSens = 100f;
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float Gravity => -gravity;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public float weight = 50f;
    public Transform rayCastSpawner;
    public LayerMask groundLayer;
    public float runSpeed = 50;
    public bool isRunning;
    public bool isGrounded;
    public bool backMovement => Input.GetKey(KeyCode.S);

    private float inputX;
    private float inputY;

    Vector3 move;
    Vector3 velocity;

    float xRotation = 0f;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Look();

        MovePlayer();

        Jumping();

        Running();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 45f);

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void MovePlayer()
    {
        isGrounded = Physics.Raycast(rayCastSpawner.position, rayCastSpawner.forward, out RaycastHit hitDetection, groundDistance, groundMask);

        Debug.DrawRay(rayCastSpawner.position, rayCastSpawner.forward * hitDetection.distance, Color.cyan);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        controller.Move(speed * Time.deltaTime * move);

        velocity.y += Gravity * Time.deltaTime * weight;

        controller.Move(velocity * Time.deltaTime);

        TwoDimAnimationController.Instance.ClampingAnim(inputX, inputY);

        TwoDimAnimationController.Instance.SetAnimation("Velocity Z", inputY);
        TwoDimAnimationController.Instance.SetAnimation("Velocity X", inputX);
    }

    private void Running()
    {
        if (!backMovement && Input.GetKey(KeyCode.LeftShift))
        {
            move = (transform.right * inputX + transform.forward * inputY) * runSpeed;
            isRunning = true;
            TwoDimAnimationController.Instance.SetAnimation("isShooting", false);
        }

        else
        {
            Debug.Log("TEST");
            move = transform.right * inputX + transform.forward * inputY;
            isRunning = false;
        }
    }

    private void Jumping()
    {
        if (!backMovement && Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * Gravity * weight);
                TwoDimAnimationController.Instance.SetAnimation("isJumping", true);
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            TwoDimAnimationController.Instance.SetAnimation("isJumping", false);
        }
    }
}
