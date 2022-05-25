using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius = 0.5f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private bool _onGround;

    private float _curentSpeed;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private int _motionState;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetInteger(AnimatorPlayerController.States.MotionState, _motionState);
        Move();
        CheckingGround();
        Jump();
    }

    private void Move()
    {
        _curentSpeed = Input.GetAxisRaw("Horizontal") * _movementSpeed;

        _rigidbody.velocity = new Vector2(_curentSpeed, _rigidbody.velocity.y);

        if (_curentSpeed == 0f)
        {
            _motionState = (int)AnimationState.Idle;
        }
        else
        {
            _motionState = (int)AnimationState.Run;
        }

        Flip();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _animator.Play(AnimatorPlayerController.States.Jump);
        }
    }

    private void CheckingGround()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _ground);
    }

    private void Flip()
    {
        float startSpeed = 0f;
        float localScaleX = 1f;

        if (_curentSpeed < startSpeed)
            transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
        else if (_curentSpeed > startSpeed)
            transform.localScale = new Vector2(localScaleX, transform.localScale.y);
        else
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    private enum AnimationState
    {
        Idle = 0,
        Run = 1
    }
}
