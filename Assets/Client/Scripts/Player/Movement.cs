using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private Vector2 movement;

    private void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        SetDirection(new Vector2(movement.x, movement.y) * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 2.5f;
        }
        else
        {
            _speed = 1.7f;
        }
        
        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        // _animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void SetDirection(Vector2 direction)
    {
        transform.Translate(direction * _speed);
    }
}
