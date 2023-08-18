using System;
using UnityEngine;


namespace AlexzanderCowell
{
    public class TwoPlayerMovementScript : MonoBehaviour
    {
        
        [Header("Character Movement")] private float
            _moveHorizontal2,
            _moveVertical2,
            _mouseXposition2,
            _mouseYposition2;
        
        private readonly String _playerTwoHorizontal = "Horizontal2";
        private readonly String _playerTwoVertical = "Vertical2";
        private readonly String _playerTwoMouseX2 = "Mouse X2";
        private readonly String _playerTwoMouseY2 = "Mouse Y2";
        private readonly String _playerTwoXboxHorizontal = "XboxHorizontal2";
        private readonly String _playerTwoXboxVertical = "XboxVertical2";
        private readonly String _playerTwoXboxMouseX2 = "XboxMouse X2";
        private readonly String _playerTwoXboxMouseY2 = "XboxMouse Y2";
        [HideInInspector] public float mouseSensitivityY, mouseSensitivityX;

        [SerializeField] private float walkSpeed;
        private static CharacterController _controller;
        private Vector3 _moveDirection2;
        private float _characterGravity;
        [SerializeField] private float downValue, upValue;
        private Transform _cameraTransform;
        private float _gravity;
        [SerializeField] public static bool _runFaster;
        private float _normalWalkSpeed;
        private bool _walkSpeedOnly;
        [SerializeField] private Camera playerCamera;
        private bool switchInputs;
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

        private void Update()
        {
                NormalMovementController();
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
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            
            if (Input.GetAxis(_playerTwoMouseX2) >= 0.5f || Input.GetAxis(_playerTwoMouseY2) >= 0.5f || Input.GetAxis(_playerTwoMouseX2) <= -0.5f ||
                Input.GetAxis(_playerTwoMouseY2) <= -0.5f)
            {
                switchInputs = true;
            }
            else if (Input.GetAxis(_playerTwoXboxMouseX2) <= -0.5f || Input.GetAxis(_playerTwoXboxMouseY2) <= -0.5f ||
                     Input.GetAxis(_playerTwoXboxHorizontal) <= -0.5f || Input.GetAxis(_playerTwoXboxVertical) <= -0.5f ||
                     Input.GetAxis(_playerTwoXboxMouseX2) >= 0.5f || Input.GetAxis(_playerTwoXboxMouseY2) >= 0.5f ||
                     Input.GetAxis(_playerTwoXboxHorizontal) >= 0.5f || Input.GetAxis(_playerTwoXboxVertical) >= 0.5f )
            {
                switchInputs = false;
            }

            if (switchInputs)
            {
                _mouseXposition2 += Input.GetAxis(_playerTwoXboxMouseX2) * mouseSensitivityX;
                _mouseYposition2-= Input.GetAxis(_playerTwoXboxMouseY2) * mouseSensitivityY;
                _mouseYposition2 = Mathf.Clamp(_mouseYposition2, downValue, upValue);
                _moveHorizontal2 = Input.GetAxis(_playerTwoXboxHorizontal); // Gets the horizontal movement of the character.
                _moveVertical2 = Input.GetAxis(_playerTwoXboxVertical); // Gets the vertical movement of the character.
            }
            else if (!switchInputs)
            {
                if (Input.GetAxis(_playerTwoXboxMouseX2) <= -0.1f || Input.GetAxis(_playerTwoXboxMouseY2) <= -0.1f ||
                    Input.GetAxis(_playerTwoXboxMouseX2) >= 0.1f || Input.GetAxis(_playerTwoXboxMouseY2) >= 0.1f)
                {
                    _mouseXposition2 += Input.GetAxis(_playerTwoXboxMouseY2) * mouseSensitivityX;
                    _mouseYposition2 += Input.GetAxis(_playerTwoXboxMouseX2) * mouseSensitivityY;
                    _mouseYposition2 = Mathf.Clamp(_mouseYposition2, downValue, upValue);
                }
                
                _moveHorizontal2 = Input.GetAxis(_playerTwoXboxHorizontal); // Gets the horizontal movement of the character.
                _moveVertical2 = Input.GetAxis(_playerTwoXboxVertical); // Gets the vertical movement of the character.
            }
          
            if (Input.GetKeyDown(KeyCode.LeftShift) || (Input.GetKeyDown(KeyCode.RightShift)))
            {
                _runFaster = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.RightShift)))
            {
                _walkSpeedOnly = true;
            }
        }

        private void ApplyGravity()
        {
            // Apply gravity to the movement direction
            _moveDirection2.y += _gravity * Time.deltaTime;

            // Move the character controller with gravity
            _controller.Move(_moveDirection2 * Time.deltaTime);
        }

    }
}
