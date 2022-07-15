using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private Transform[] _spawner;
    [SerializeField] private float _yAxis;
    [SerializeField] private float _range = 300;

    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeSpawn);
    }

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private Vector3 GetMoveVector()
    {
        float x = Random.Range(-_range, _range);
        float z = Random.Range(-_range, _range);

        return new Vector3(x, _yAxis, z);
    }

    private IEnumerator SpawnObjects()
    {
        yield return _waitForSeconds;

        int index = Random.Range(0, _spawner.Length);
        var spawnPosition = _spawner[index].position;
        var enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
        enemy.AddForce(GetMoveVector());
    }
}
