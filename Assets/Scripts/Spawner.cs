using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private float _spawnDelay = 2;

    [SerializeField] private Transform[] _points;
    private float _runningTime;
    private int _currentPoint = 0;

    private void Update()
    {
        _runningTime += Time.deltaTime;

        if (_runningTime >= _spawnDelay)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        _runningTime = 0;

        Instantiate(_prefab, _points[_currentPoint].position, Quaternion.identity);

        _currentPoint++;

        if (_currentPoint >= _points.Length)
            _currentPoint = 0;
    }
}
