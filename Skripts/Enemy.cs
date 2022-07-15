using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void AddForce(Vector3 direction)
    {
        _rigidbody.AddForce(direction);
    }
}
