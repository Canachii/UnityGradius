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
        transform.Translate(data.direction.normalized * data.speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(data.colliderTag) && data.penetrate)
        {
            other.GetComponent<Health>().TakeDamage(data.damage);
        }
        else if (other.CompareTag(data.colliderTag) && !data.penetrate)
        {
            other.GetComponent<Health>().TakeDamage(data.damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
    }
}