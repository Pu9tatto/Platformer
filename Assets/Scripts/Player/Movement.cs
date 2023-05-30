using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private readonly int IsMove = Animator.StringToHash("IsMove");

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private int _rightDirection = 1;
    private int _leftDirection = -1;
    private float _velocityX = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            _velocityX = _speed * Time.deltaTime * _rightDirection;
            Move(_velocityX);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            _velocityX = _speed * Time.deltaTime * _leftDirection;
            Move(_velocityX);
        }
        else
        {
            _velocityX = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        SetAnimations();
    }

    private void Move(float velocityX)
    {
        transform.Translate(velocityX, 0, 0);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void SetAnimations()
    {
        _animator.SetBool(IsMove, _velocityX != 0);
    }
}
