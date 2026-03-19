using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputActionAsset _inputActions;
    [SerializeField] private InputActionReference _moveAction;

    private Rigidbody2D _rigidBody;

    private void OnEnable() => _moveAction.action.Enable();
    private void OnDisable() => _moveAction.action.Disable();

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 input = _moveAction.action.ReadValue<Vector2>();
        Vector2 newPosition = new Vector2(_rigidBody.position.x, _rigidBody.position.y + input.y * _speed * Time.fixedDeltaTime);

        _rigidBody.MovePosition(newPosition);
    }
}
