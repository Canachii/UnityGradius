using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Health _health;
    private Animator _animator;

    [Header("Drop")] public GameObject dropItem;
    public float dropChance = 0.1f;

    private void Start()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();

        _health.OnDead += () => { _animator.SetTrigger("Dead"); };
    }

    private void Update()
    {
        if (_health.isDead) return;
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(1);
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
    }

    protected virtual void Attack()
    {
    }

    public virtual void OnEnemyDead()
    {
        if (dropItem && dropChance >= Random.value)
        {
            Instantiate(dropItem, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}