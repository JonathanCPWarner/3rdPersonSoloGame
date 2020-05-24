using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region PUBLIC VARIABLES
    [Header("Inputs")]
    public float InputX;
    public float InputZ;

    [Header("Player Speed")]
    public float currentSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float movementSpeed;
    public float jumpHeight;

    [Header("Gravity")]
    public float gravity = -9.81f;

    [Header("Player Movement Allowance")]
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public float allowPlayerRotation;
    public Vector3 moveVector;

    [Header("Animation")]
    public Animator anim;

    [Header("Controllers")]
    public Camera cam;
    public CharacterController controller;

    [Header("GroundCheck")]
    public bool isGrounded;
    public float groundDistance;
    public LayerMask groundMask;
    public Transform groundCheck;

 /*   [Header("GameProps")]
    public GameObject woodBarricade;
    public Text woodCollectText;
    */
    #endregion
    bool _isShiftPressedDown;
    Vector3 _velocity;
    int countCollect;

    #region MOVEMENT
    private void Start()
    {
        #region REMOVE MOUSE
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        #endregion

        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        InputMagnitude();

        controller.Move(moveVector);

        #region  GROUND CHECK
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
        #endregion

        #region JUMP
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        #endregion

        #region ANIMATION CHECK
        if (currentSpeed == 0)
        {
            anim.SetBool("isWalking", false); ;
            anim.SetBool("isIdle", true);
        }
        else if (currentSpeed != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
        }
        if (_isShiftPressedDown == true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        #endregion

        movementSpeed = _isShiftPressedDown ? runSpeed : walkSpeed;
    }

    void PlayerMoveandRotation()
    {

        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        //Finding the forward / right look values for movement
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        //Sets the forward/right variables to 1
        forward.Normalize();
        right.Normalize();

        //Finds the direction to walk
        desiredMoveDirection = forward * InputZ + right * InputX;
        desiredMoveDirection = Vector3.ClampMagnitude(desiredMoveDirection, 1);

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }

        controller.Move(desiredMoveDirection * Time.deltaTime * currentSpeed * movementSpeed);
    }

    public void InputMagnitude()
    {
        //Calculate the Input Vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime * 2f);
        anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        currentSpeed = (new Vector2(InputX, InputZ).normalized.sqrMagnitude);

        //Physically move player
        if (currentSpeed > allowPlayerRotation)

            PlayerMoveandRotation();
    }

    private void OnGUI()
    {
        //Swap between Walk and Run
        _isShiftPressedDown = Event.current.shift;
    }
    #endregion
 /*   private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            col.gameObject.SetActive(false);
            countCollect = countCollect + 1;
            SetDisplayText();

            FindObjectOfType<AudioManager>().Play("Collectible");
        }
    }

    private void SetDisplayText()
    {
        woodCollectText.text = "Wood = " + countCollect.ToString();
        if (countCollect >= 3)
        {
            woodBarricade.SetActive(false);
        }
    }*/
}

