using UnityEngine;

public class PointPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed = 2;

    private int _currentPoint;

    private void Update()
    {
        float newPositionX = Mathf.MoveTowards(transform.position.x, _points[_currentPoint].position.x, _speed * Time.deltaTime);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        if(transform.position.x == _points[_currentPoint].position.x)
        {
            _currentPoint++;

            if(_currentPoint>=_points.Length)
                _currentPoint = 0;
        }
    }
}
