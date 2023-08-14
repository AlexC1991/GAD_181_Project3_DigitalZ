using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Character Movement")] private float _mouseXposition,
            _moveHorizontal,
            _moveVertical,
            _mouseYposition;
        
        private readonly String _playerOneXboxHorizontal = "XboxHorizontal1";
        private readonly String _playerOneXboxVertical = "XboxVertical1";
        private readonly String _playerOneXboxMouseX1 = "XboxMouse X1";
        private readonly String _playerOneXboxMouseY1 = "XboxMouse Y1";

        [HideInInspector] public float mouseSensitivityY, mouseSensitivityX;

        [SerializeField] private float walkSpeed;
        public static CharacterController _controller;
        private Vector3 _moveDirection;
        private float _characterGravity;
        [SerializeField] private float downValue, upValue;
        private Transform _cameraTransform;
        private float _gravity;
        private bool _runFaster;
        private float _normalWalkSpeed;
        private bool _walkSpeedOnly;
        private bool switchInputs;
        [SerializeField] private Camera playerCamera;
        //[FormerlySerializedAs("_animator")] [Header("Character Animations")] [SerializeField]
        //private Animator animator;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None; // Lock the cursor to the center of the screen
            Cursor.visible = true;
            _gravity = -20;
            mouseSensitivityY = 0.7f;
            mouseSensitivityX = 1;
            _normalWalkSpeed = walkSpeed;
            _runFaster = false;
        }

        private void FixedUpdate()
        {
            NormalMovementController();
        }

        private void Update()
        {
               
            ApplyGravity();

            if (_runFaster)
            {
                walkSpeed *= 2;
                _runFaster = false;
            }
            else if (_walkSpeedOnly)
            {
                walkSpeed = _normalWalkSpeed;
                _walkSpeedOnly = false;
            }
            
            // // Set the camera and character controller to look in the same direction and continuously updates.
            // _cameraTransform = playerCamera.transform;
            // _cameraTransform.position = transform.position;
        }

        private void NormalMovementController()
        {
            if (Input.GetAxis("Mouse X") >= 0.5f || Input.GetAxis("Mouse Y") >= 0.5f || Input.GetAxis("Mouse X") <= -0.5f ||
                Input.GetAxis("Mouse Y") <= -0.5f)
            {
                switchInputs = true;
            }
            else if (Input.GetAxis(_playerOneXboxMouseX1) <= -0.5f || Input.GetAxis(_playerOneXboxMouseY1) <= -0.5f ||
                     Input.GetAxis(_playerOneXboxHorizontal) <= -0.5f || Input.GetAxis(_playerOneXboxVertical) <= -0.5f ||
                     Input.GetAxis(_playerOneXboxMouseX1) >= 0.5f || Input.GetAxis(_playerOneXboxMouseY1) >= 0.5f ||
                     Input.GetAxis(_playerOneXboxHorizontal) >= 0.5f || Input.GetAxis(_playerOneXboxVertical) >= 0.5f )
            {
                switchInputs = false;
            }

            if (switchInputs)
            {
                _mouseXposition += Input.GetAxis("Mouse X") * mouseSensitivityX;
                _mouseYposition -= Input.GetAxis("Mouse Y") * mouseSensitivityY;
                _mouseYposition = Mathf.Clamp(_mouseYposition, downValue, upValue);
                _moveHorizontal = Input.GetAxis("Horizontal"); // Gets the horizontal movement of the character.
                _moveVertical = Input.GetAxis("Vertical"); // Gets the vertical movement of the character.
            }
            else if (!switchInputs)
            {
                if (Input.GetAxis(_playerOneXboxMouseX1) <= -0.1f || Input.GetAxis(_playerOneXboxMouseY1) <= -0.1f ||
                    Input.GetAxis(_playerOneXboxMouseX1) >= 0.1f || Input.GetAxis(_playerOneXboxMouseY1) >= 0.1f)
                {
                    _mouseXposition += Input.GetAxis(_playerOneXboxMouseY1) * mouseSensitivityX;
                    _mouseYposition += Input.GetAxis(_playerOneXboxMouseX1) * mouseSensitivityY;
                    _mouseYposition = Mathf.Clamp(_mouseYposition, downValue, upValue);
                }
                
                _moveHorizontal = Input.GetAxis(_playerOneXboxHorizontal); // Gets the horizontal movement of the character.
                _moveVertical = Input.GetAxis(_playerOneXboxVertical); // Gets the vertical movement of the character.
            }
            
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            // Get the mouse input and apply it to the camera and player and lock the camera upValue & downValue so it can only look up & down in a certain degree.
    
          transform.rotation = Quaternion.Euler(_mouseYposition, _mouseXposition, 0f);
          playerCamera.transform.rotation = Quaternion.Euler(_mouseYposition, _mouseXposition, 0f);
          Vector3 movement = new Vector3(_moveHorizontal, 0f, _moveVertical); // Allows the character to move forwards and backwards & left & right.
          movement = transform.TransformDirection(movement) * walkSpeed; // Gives the character movement speed.
          _controller.Move((movement + _moveDirection) * Time.deltaTime); // Gets all the movement variables and moves the character.
          
          if (Input.GetKeyDown(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.RightShift)) || Input.GetKeyDown(KeyCode.Joystick1Button8))
          {
              _runFaster = true;
          }

          if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.RightShift)) || Input.GetKeyDown(KeyCode.Joystick1Button8))
          {
              _walkSpeedOnly = true;
          }
        }

        private void ApplyGravity()
        {
            // Apply gravity to the movement direction
            _moveDirection.y += _gravity * Time.deltaTime;

            // Move the character controller with gravity
            _controller.Move(_moveDirection * Time.deltaTime);
        }
    }
}
    
