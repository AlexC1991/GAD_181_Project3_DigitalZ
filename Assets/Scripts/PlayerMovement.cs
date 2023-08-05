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
        [SerializeField] private Camera playerCamera;
        //[FormerlySerializedAs("_animator")] [Header("Character Animations")] [SerializeField]
        //private Animator animator;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            _gravity = -20;
            mouseSensitivityY = 0.7f;
            mouseSensitivityX = 1;
            _normalWalkSpeed = walkSpeed;
            _runFaster = false;
        }

        private void Update()
        {
            HandleMovement();
            ApplyGravity();

            if (Input.GetKeyDown(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.RightShift)))
            {
                _runFaster = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.RightShift)))
            {
                _walkSpeedOnly = true;
            }

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

        private void HandleMovement()
        {
            // Get the mouse input and apply it to the camera and player and lock the camera upValue & downValue so it can only look up & down in a certain degree.
          _mouseXposition += Input.GetAxis("Mouse X") * mouseSensitivityX;
          _mouseYposition -= Input.GetAxis("Mouse Y") * mouseSensitivityY;
          _mouseYposition = Mathf.Clamp(_mouseYposition, downValue, upValue);
          
          transform.rotation = Quaternion.Euler(_mouseYposition, _mouseXposition, 0f);
          playerCamera.transform.rotation = Quaternion.Euler(_mouseYposition, _mouseXposition, 0f);
          _moveHorizontal = Input.GetAxis("Horizontal"); // Gets the horizontal movement of the character.
          _moveVertical = Input.GetAxis("Vertical"); // Gets the vertical movement of the character.
          Vector3 movement = new Vector3(_moveHorizontal, 0f, _moveVertical); // Allows the character to move forwards and backwards & left & right.
          movement = transform.TransformDirection(movement) * walkSpeed; // Gives the character movement speed.
          _controller.Move((movement + _moveDirection) * Time.deltaTime); // Gets all the movement variables and moves the character.
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
    
