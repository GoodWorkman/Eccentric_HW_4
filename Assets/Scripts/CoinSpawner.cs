using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private int _coinsCount = 10;
    [SerializeField] private float _checkRadius = 1.5f;
    [SerializeField] private float _yCheckoffcet = 2f;

    [SerializeField] private Transform _coinContainer;
    [SerializeField] private Coin _coinPrefab;

    [SerializeField] private Transform _spawnCornerA;
    [SerializeField] private Transform _spawnCornerB;

    private void Awake()
    {
        SpawnCoin(_coinsCount);
    }
    
    private void OnDrawGizmos()
    {
        Vector3 center = (_spawnCornerA.position + _spawnCornerB.position) / 2;
        Vector3 size = _spawnCornerB.position - _spawnCornerA.position;
        
        Gizmos.DrawWireCube(center, size);
    }

    private void SpawnCoin(int size)
    {
        for (int i = 0; i < size; i++)
        {
            TrySpawnObject();
            Debug.Log("SpawnCoin");
        }
    }

    private void TrySpawnObject()
    {
        int attempts = 10;
        Debug.Log("TrySpawnCoin");


        for (int i = 0; i < attempts; i++)
        {
            Vector3 spawnPosition = GeneratePosition();

            Vector3 currentYCheck = new Vector3(spawnPosition.x, spawnPosition.y + _yCheckoffcet, spawnPosition.z);

            Collider[] colliders = Physics.OverlapSphere(currentYCheck, _checkRadius);
            Debug.Log(colliders.Length);

            if (colliders.Length == 0)
            {
                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
                
                Instantiate(_coinPrefab, spawnPosition, randomRotation, _coinContainer);
                break;
            }
        }
    }

    private Vector3 GeneratePosition()
    {
        float coordX = Random.Range(_spawnCornerA.position.x, _spawnCornerB.position.x);
        float coordY = 0f;
        float coordZ = Random.Range(_spawnCornerA.position.z, _spawnCornerB.position.z);

        return new Vector3(coordX, coordY, coordZ);
    }
}
