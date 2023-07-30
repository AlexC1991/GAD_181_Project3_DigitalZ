using UnityEngine;
using UnityEngine.Serialization;

namespace AlexzanderCowell
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameObject spawnPoint;
        
        [Header("Character Movement")]
        private float _mouseXposition,
            _moveHorizontal,
            _moveVertical,
            _mouseYposition;

        [HideInInspector] public float mouseSensitivityY,
            mouseSensitivityX;
        [SerializeField] private float walkSpeed;
        private CharacterController _controller;
        private Vector3 _moveDirection;
        private float _characterGravity;
        [SerializeField] private float downValue, upValue;
        private Transform _cameraTransform;
        private float _gravity;
        private bool _runFaster;
        private float _normalWalkSpeed;
        private bool _walkSpeedOnly;
        private Vector3 _startingPosition;
        [SerializeField] private Camera playerCamera;
        

        private void Start()
        { 
            _startingPosition = spawnPoint.transform.position;
        _controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        _gravity = -20;
        mouseSensitivityY = 0.7f;
        mouseSensitivityX = 1;
        _normalWalkSpeed = walkSpeed;
        _runFaster = false;
        _controller.transform.position = _startingPosition;
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
    }

    private void HandleMovement()
    {
             // Get mouse input for rotation
            _mouseXposition += mouseSensitivityX * Input.GetAxis("Mouse X"); // grabs the mouse X axis every frame for the rotation movement.
            _mouseYposition -= mouseSensitivityY * Input.GetAxis("Mouse Y"); // grabs the mouse Y axis every frame for the rotation movement.
            _moveHorizontal = Input.GetAxis("Horizontal"); // Gets the horizontal movement of the character.
            _moveVertical = Input.GetAxis("Vertical"); // Gets the vertical movement of the character.
            transform.rotation = Quaternion.Euler(0f, _mouseXposition, 0f);
            playerCamera.transform.rotation = Quaternion.Euler(_mouseYposition, _mouseXposition, 0f);
            _mouseYposition = Mathf.Clamp(_mouseYposition, downValue, upValue);
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