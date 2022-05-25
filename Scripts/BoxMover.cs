using UnityEngine;

public class BoxMover : MonoBehaviour
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

        if (transform.position == target.position)
        {
            _curentPoint++;

            if (_curentPoint >= _points.Length)
            {
                _curentPoint = 0;
            }
        }
    }
}
