using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Health _health;
    protected Animator Animator;

    [Header("Drop")] public GameObject dropItem;
    public float dropChance = 0.1f;
    
    [Header("Spec")]
    public float speed = 5f;

    protected virtual void Start()
    {
        _health = GetComponent<Health>();
        Animator = GetComponent<Animator>();

        _health.OnDead += () => { Animator.SetTrigger("Dead"); };
    }

    protected virtual void Update()
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
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    public void OnEnemyDead()
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