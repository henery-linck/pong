using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputActionAsset _inputActions;
    [SerializeField] private InputActionReference _moveAction;

    private Rigidbody2D _rigidbody;

    private void OnEnable() => _moveAction.action.Enable();
    private void OnDisable() => _moveAction.action.Disable();

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 input = _moveAction.action.ReadValue<Vector2>();
        Vector2 movement = new Vector2(0, input.y);

        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
