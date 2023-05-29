using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    public void Spawn()
    {
        Instantiate(_prefab, transform.position, Quaternion.identity);
    }
}
