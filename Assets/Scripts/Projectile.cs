using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData data;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = data.sprite;
    }

    private void Update()
    {
        transform.Translate(data.dir.normalized * data.speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(data.colliderTag))
        {
            other.GetComponent<Health>().TakeDamage(data.damage);
            if (!data.penetrate)
            {
                Destroy(gameObject);
            }
        }
    }
}