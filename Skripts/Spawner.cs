using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Rigidbody  _enemy;
    [SerializeField] private float  _TimeSpanw;
    [SerializeField] private Transform[]  _spawner;
    [SerializeField] private float _yAxis;

    private IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(_TimeSpanw);

        int index = Random.Range(0, _spawner.Length);
        var spawnPosition = _spawner[index].position;
        var enemy = Instantiate( _enemy, spawnPosition, Quaternion.identity);
        enemy.AddForce(GetMoveVector());

    }

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private Vector3 GetMoveVector()
    {
        float x = Random.Range(-300, 300);
        float z = Random.Range(-300, 300);

        return new Vector3(x, _yAxis, z);
    }
}
