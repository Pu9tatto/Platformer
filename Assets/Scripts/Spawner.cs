using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private float _spawnDelay = 2;
    [SerializeField] private Transform[] _points;

    private bool _isSpawning = true;
    private int _currentPoint = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(_spawnDelay));
    }

    private IEnumerator SpawnEnemy(float spawnDelay)
    {
        var waitForSpawnDelay = spawnDelay;

        while (_isSpawning)
        {
            Instantiate(_prefab, _points[_currentPoint].position, Quaternion.identity);

            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;

            yield return new WaitForSeconds(waitForSpawnDelay);
        }
    }
}
