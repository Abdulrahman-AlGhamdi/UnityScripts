using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float _verticalInput;
    private float _horizontalInput;
    private int IsWalking;

    private Animator _animator;
    private Rigidbody _rigidbody;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private void Start() {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

        IsWalking = Animator.StringToHash("isWalking");
    }

    private void Update() {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        PlayerMovement();
        PlayerDirection();
        PlayerAnimation();
    }

    private void PlayerMovement() {
        var zVelocity = _verticalInput * movementSpeed;
        var xVelocity = _horizontalInput * movementSpeed;
        _rigidbody.velocity = new Vector3(xVelocity, _rigidbody.velocity.y, zVelocity);
    }

    private void PlayerDirection() {
        if (_rigidbody.velocity == Vector3.zero) return;

        var playerDirection = new Vector3(_horizontalInput, 0, _verticalInput);
        var rotationDirection = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationDirection, rotationSpeed);
    }

    private void PlayerAnimation() {
        if (_verticalInput != 0 || _horizontalInput != 0) _animator.SetBool(IsWalking, true);
        if (_verticalInput == 0 && _horizontalInput == 0) _animator.SetBool(IsWalking, false);
    }

}