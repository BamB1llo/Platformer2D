using UnityEngine;

public class GolemMover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;

    private Transform[] _points;
    private int _curentPoint;

    private void Start()
    {
        _points = new Transform[] { _point1, _point2 };
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Transform target = _points[_curentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _movementSpeed * Time.deltaTime);

        Flip(target);

        if (transform.position == target.position)
        {
            _curentPoint++;

            if (_curentPoint >= _points.Length)
            {
                _curentPoint = 0;
            }
        }
    }

    private void Flip(Transform target)
    {
        float localScaleX = 1f;

        if (transform.position != target.position && _curentPoint == 0)
            transform.localScale = new Vector2(localScaleX, transform.localScale.y);
        else if (transform.position != target.position && _curentPoint == 1)
            transform.localScale = new Vector2(-localScaleX, transform.localScale.y);
        else
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }
}
