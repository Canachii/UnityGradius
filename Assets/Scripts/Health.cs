using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Health : MonoBehaviour
{
    [HideInInspector] public bool isDead;
    public int health = 1;

    public Action OnDead;

    private Rigidbody2D _rigidbody;

    private void Reset()
    {
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Start()
    {
        isDead = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            isDead = true;
            OnDead?.Invoke();
        }
    }
}