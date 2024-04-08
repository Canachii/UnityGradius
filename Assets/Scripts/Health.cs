using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Health : MonoBehaviour
{
    [HideInInspector] public bool isDead;
    public int health = 1;

    public Action OnDead;

    private Collider2D _collider;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        isDead = false;
        _collider = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            _collider.enabled = false;
            isDead = true;
            OnDead?.Invoke();
        }
    }
}