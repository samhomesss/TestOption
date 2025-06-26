using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D _rb;
    public float _moveSpeed;

    public bool _isFired;

    Vector2 _moveDirection;

    public InputActionReference move; // ��ǲ �ý��� ������ �����;� �� 
    public InputActionReference fire;

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>(); // � ���� �о �����ðǰ�

    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
    }

    private void OnEnable()
    {
        fire.action.started += Fire;
    }

    private void OnDisable()
    {
        fire.action.started -= Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        Debug.Log("Fired");
    }
}
