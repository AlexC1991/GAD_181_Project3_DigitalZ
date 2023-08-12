using UnityEngine;

namespace AlexzanderCowell
{
    
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivityX = 1f;
        [SerializeField] private float mouseSensitivityY = 1f;
        [SerializeField] private float walkSpeed = 1f;
        [SerializeField] private float upValue = 90f;
        [SerializeField] private float downValue = -90f;
        private float _mouseXposition;
        private float _mouseYposition;
        private float _moveHorizontal;
        private float _moveVertical;
        private CharacterController _controller;
        private Vector3 _moveDirection;
        [SerializeField] private Camera playerCamera;
        private void Update()
        {
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
        }
}
