using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class PlayerOneMovementScript : MonoBehaviour
    {
        [SerializeField] private float walkSpeed;
        public static CharacterController _controller;
        private Vector3 _moveDirection;
        private float _characterGravity;
        private Transform _cameraTransform;
        private float _gravity;
        private bool _runFaster;
        private float _normalWalkSpeed;
        private bool _walkSpeedOnly;
        [SerializeField] private Camera playerCamera;
        private float rotationSpeed;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            ApplyGravity();

            if (GameModeSelection._moreThanOnePlayer && !GameModeSelection._moreThanOnePlayerCheck2)
            {
                MovementForPlayerOne();
            }
        }

        private void MovementForPlayerOne()
        {
            Vector3 moveDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                moveDirection += transform.forward;
            if (Input.GetKey(KeyCode.S))
                moveDirection -= transform.forward;
            if (Input.GetKey(KeyCode.A))
                moveDirection -= transform.right;
            if (Input.GetKey(KeyCode.D))
                moveDirection += transform.right;

            // Normalize the movement vector to ensure consistent speed in all directions
            moveDirection.Normalize();
            _controller.Move(moveDirection * walkSpeed * Time.deltaTime);

            // Camera Rotation
            if (Input.GetKey(KeyCode.E))
                playerCamera.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.F))
                playerCamera.transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _runFaster = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
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
    
