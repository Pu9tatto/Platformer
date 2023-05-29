using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 2;

    private PointSpawner[] _points;
    private float _runningTime;
    private int _currentPoint = 0;

    private void Awake()
    {
        _points = GetComponentsInChildren<PointSpawner>();
    }

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

        _points[_currentPoint].Spawn();

        _currentPoint++;

        if (_currentPoint >= _points.Length)
            _currentPoint = 0;
    }
}
