using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float _xInput;
    private float _zInput;
    private Rigidbody _rigidbody;

    [SerializeField] private float moveSpeed;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        _xInput = Input.GetAxis("Horizontal");
        _zInput = Input.GetAxis("Vertical");

        KeyboardMovement();
    }

    private void KeyboardMovement() {
        var xVelocity = _xInput * moveSpeed;
        var zVelocity = _zInput * moveSpeed;

        _rigidbody.velocity = new Vector3(xVelocity, _rigidbody.velocity.y, zVelocity);
    }
}